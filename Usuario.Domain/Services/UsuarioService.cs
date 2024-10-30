using Usuario.Domain.Builders;
using Usuario.Infrastructure.Commands;
using Usuario.Infrastructure.EntityFrameworkCore;
using Usuario.Infrastructure.Repositories;

namespace Usuario.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ApplicationDbContext _context;
        private readonly IUsuarioBuilder _usuarioBuilder;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            ApplicationDbContext context,
            IUsuarioBuilder usuarioBuilder)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
            _usuarioBuilder = usuarioBuilder;
        }

        public async Task Adicionar(InserirUsuarioCommand comando)
        {
            var usuario = new Usuario();
            usuario.Inserir(comando);
            await _usuarioRepository.Inserir(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(AtualizarUsuarioCommand comando)
        {
            var usuarioAtualizar = await _usuarioBuilder.Build(comando.Id);
            usuarioAtualizar.Atualizar(comando);
            await _usuarioRepository.Atualizar(usuarioAtualizar);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            await _usuarioRepository.Excluir(id);
            await _context.SaveChangesAsync();
        }
    }
}