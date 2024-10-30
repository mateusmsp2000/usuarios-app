using Microsoft.AspNetCore.Mvc;
using Usuario.Domain.Services;
using Usuario.Host.ApplicationServices;
using Usuario.Host.Builders;
using Usuario.Host.DTOs;
using Usuario.Host.Localizacao.DTOs;

namespace Usuario.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService; 
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public UsuarioController(
            IUsuarioService usuarioService,
            IUsuarioApplicationService usuarioApplicationService)
        {
            _usuarioService = usuarioService;
            _usuarioApplicationService = usuarioApplicationService;
        }
        
        [HttpPost]
        public async Task<ActionResult<Domain.Usuario>> CreateUsuario(InserirUsuarioInput comando)
        {
            var usuarioAleatorio = await _usuarioApplicationService.ObterUsuarioAleatorio();

            var localizacao = new InserirLocalizacaoInput()
            {
                IdUsuario = comando.Id,
                Pais = usuarioAleatorio.Location.Country,
                Cidade = usuarioAleatorio.Location.City,
            };

            comando = new InserirUsuarioInput()
            {
                Email = usuarioAleatorio.Email,
                PrimeiroNome = usuarioAleatorio.Name.First,
                UltimoNome = usuarioAleatorio.Name.Last,
                Telefone = usuarioAleatorio.Phone,
                Genero = usuarioAleatorio.Gender,
                Localizacoes = [localizacao]
            };
            
            var teste = DomainCommandsBuilder.BuildInserirUsuarioCommand(comando);
            await _usuarioService.Adicionar(teste);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateUsuario(AtualizarUsuarioInput usuario)
        {
            var teste = DomainCommandsBuilder.BuildAtualizarUsuarioCommand(usuario);
            await _usuarioService.Atualizar(teste);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            await _usuarioService.Remover(id);
            return NoContent();
        }
    }
}
