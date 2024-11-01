using Usuario.Infrastructure.EntityFrameworkCore;

namespace Usuario.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Domain.Usuario> Inserir(Domain.Usuario usuario)
        {
            await _context.Usuarios.AddRangeAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        
        public async Task Atualizar(Domain.Usuario usuarios)
        {
            _context.Usuarios.UpdateRange(usuarios);
            await _context.SaveChangesAsync();
        }
        
        public async Task Excluir(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}