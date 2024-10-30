using Microsoft.EntityFrameworkCore;
using Usuario.Infrastructure.EntityFrameworkCore;

namespace Usuario.Infrastructure.Repositories.Read;

public class UsuarioReadRepository : IUsuarioReadRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioReadRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Domain.Usuario>> BuscarTodos()
    {
        return await _context.Usuarios
            .Include(u => u.Localizacoes)
            .AsNoTracking()
            .ToListAsync();
    }
        
    public async Task<Domain.Usuario> BuscarPorId(Guid id)
    {
        return await _context.Usuarios.FindAsync(id);
    }
}