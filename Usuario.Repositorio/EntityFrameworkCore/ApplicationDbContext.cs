using Microsoft.EntityFrameworkCore;
using Usuario.Infrastructure.Models.Localizacoes;

namespace Usuario.Infrastructure.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Domain.Usuario> Usuarios { get; set; }
    public DbSet<Localizacao> UsuarioLocalizacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PrimeiroNome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.UltimoNome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(256);
            entity.Property(e => e.DataNascimento).IsRequired();
            entity.Property(e => e.Genero).HasMaxLength(10);
            entity.Property(e => e.Telefone).HasMaxLength(20);
            
            entity.HasMany(e => e.Localizacoes)
                .WithOne(l => l.Usuario)
                .HasForeignKey(l => l.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Localizacao>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Cidade).HasMaxLength(50);
            entity.Property(e => e.Pais).HasMaxLength(50);
        });
    }
}