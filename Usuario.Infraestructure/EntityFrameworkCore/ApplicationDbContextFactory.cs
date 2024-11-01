using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Usuario.Infrastructure.EntityFrameworkCore
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var projectPath = Path.Combine(Directory.GetCurrentDirectory(), "../Usuarios.Host");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}