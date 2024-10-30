using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Usuario.Infrastructure.EntityFrameworkCore
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Altere o caminho para o diretório onde o appsettings.json do Usuarios.Host está localizado
            var projectPath = Path.Combine(Directory.GetCurrentDirectory(), "../Usuarios.Host");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Obtém a ConnectionString do arquivo de configuração
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configura o DbContext para usar PostgreSQL
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}