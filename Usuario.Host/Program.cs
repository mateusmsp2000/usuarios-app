using Microsoft.EntityFrameworkCore;
using Usuario.Application.Services;
using Usuario.Domain.Services;
using Usuario.Domain.Services.ValidatorService;
using Usuario.Host.ApplicationServices;
using Usuario.Infrastructure.Builders;
using Usuario.Infrastructure.EntityFrameworkCore;
using Usuario.Infrastructure.Repositories;
using Usuario.Infrastructure.Repositories.Read;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(); 

builder.Services.AddHttpClient();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IUsuarioValidatorService, UsuarioValidatorService>();
builder.Services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
builder.Services.AddTransient<IUsuarioBuilder, UsuarioBuilder>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioReadRepository, UsuarioReadRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();
