using Microsoft.EntityFrameworkCore;
using Usuario.Infrastructure.EntityFrameworkCore;

namespace Usuario.Domain.Builders
{
    public class UsuarioBuilder : IUsuarioBuilder
    {
        private readonly ApplicationDbContext _context;
        private bool _asNoTracking;

        public UsuarioBuilder(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUsuarioBuilder AsNoTracking()
        {
            _asNoTracking = true;
            return this;
        }
        
        public async Task<Usuario?> Build(Guid id)
        {
            var query = _context.Usuarios
                .Include(u => u.Localizacoes)  
                .Where(u => u.Id == id);

            if (_asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}