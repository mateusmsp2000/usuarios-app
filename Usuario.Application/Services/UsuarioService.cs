using Usuario.Commands;
using Usuario.Domain.Enums;
using Usuario.Domain.Services;
using Usuario.Domain.Services.ValidatorService;
using Usuario.Infrastructure.Builders;
using Usuario.Infrastructure.EntityFrameworkCore;
using Usuario.Infrastructure.Repositories;

namespace Usuario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ApplicationDbContext _context;
        private readonly IUsuarioBuilder _usuarioBuilder;
        private readonly IUsuarioValidatorService _usuarioValidatorService;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            ApplicationDbContext context,
            IUsuarioBuilder usuarioBuilder,
            IUsuarioValidatorService usuarioValidatorService)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
            _usuarioBuilder = usuarioBuilder;
            _usuarioValidatorService = usuarioValidatorService;
        }

        public async Task<InserirUsuarioValidacaoEnum> Adicionar(InserirUsuarioCommand comando)
        {
            
            var usuario = new Domain.Usuario();
            var resultadoValidacao = usuario.Inserir(comando, _usuarioValidatorService);
            if (resultadoValidacao != InserirUsuarioValidacaoEnum.Ok)
            {
                return resultadoValidacao;
            }
            await _usuarioRepository.Inserir(usuario);
            await _context.SaveChangesAsync();
            return resultadoValidacao;
        }

        public async Task<AtualizarUsuarioValidacaoEnum> Atualizar(AtualizarUsuarioCommand comando)
        {
            var usuarioAtualizar = await _usuarioBuilder.Build(comando.Id);
            var resultadoValidacao = usuarioAtualizar.Atualizar(comando, _usuarioValidatorService);
            if (resultadoValidacao != AtualizarUsuarioValidacaoEnum.Ok)
            {
                return resultadoValidacao;
            }
            await _usuarioRepository.Atualizar(usuarioAtualizar);
            await _context.SaveChangesAsync();
            return resultadoValidacao;
        }

        public async Task Remover(Guid id)
        {
            await _usuarioRepository.Excluir(id);
            await _context.SaveChangesAsync();
        }
    }
}