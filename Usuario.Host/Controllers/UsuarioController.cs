using Microsoft.AspNetCore.Mvc;
using Usuario.Application.Services;
using Usuario.Domain.Enums;
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
        private readonly IUsuarioAleatorioAppService _usuarioAleatorioAppService;

        public UsuarioController(
            IUsuarioService usuarioService,
            IUsuarioAleatorioAppService usuarioAleatorioAppService)
        {
            _usuarioService = usuarioService;
            _usuarioAleatorioAppService = usuarioAleatorioAppService;
        }
        
        [HttpPost]
        public async Task<ActionResult<Domain.Usuario>> Adicionar(InserirUsuarioInput comando)
        {
            var resultadoValidacao = await _usuarioService.Adicionar(DomainCommandsBuilder.BuildInserirUsuarioCommand(comando));
            if (resultadoValidacao != InserirUsuarioValidacaoEnum.Ok)
            {
                return BadRequest(resultadoValidacao);
            }
            return Ok(resultadoValidacao);
        }
        
        [HttpPost]
        [Route("usuarioAleatorio")]
        public async Task<ActionResult<Domain.Usuario>> AdicionarUsuarioAleatorio()
        {
            var usuarioAleatorio = await _usuarioAleatorioAppService.ObterUsuarioAleatorio();

            var localizacao = new InserirLocalizacaoInput()
            {
                Pais = usuarioAleatorio.Location.Country,
                Cidade = usuarioAleatorio.Location.City,
            };

            var comando = new InserirUsuarioInput()
            {
                Email = usuarioAleatorio.Email,
                PrimeiroNome = usuarioAleatorio.Name.First,
                UltimoNome = usuarioAleatorio.Name.Last,
                Telefone = usuarioAleatorio.Phone,
                Genero = usuarioAleatorio.Gender,
                Localizacoes = [localizacao]
            };
            
            var resultadoValidacao = await _usuarioService.Adicionar(DomainCommandsBuilder.BuildInserirUsuarioCommand(comando));
            if (resultadoValidacao != InserirUsuarioValidacaoEnum.Ok)
            {
                return BadRequest(resultadoValidacao);
            }
            return Ok(resultadoValidacao);
        }
        
        [HttpPut]
        public async Task<IActionResult> Atualizar(AtualizarUsuarioInput usuario)
        {
            var resultadoValidacao =
                await _usuarioService.Atualizar(DomainCommandsBuilder.BuildAtualizarUsuarioCommand(usuario));
            if (resultadoValidacao != AtualizarUsuarioValidacaoEnum.Ok)
            {
                return BadRequest(resultadoValidacao);
            }
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _usuarioService.Remover(id);
            return NoContent();
        }
    }
}
