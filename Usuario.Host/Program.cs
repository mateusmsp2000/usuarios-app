    using Microsoft.EntityFrameworkCore;
    using Usuario.Application.Services;
    using Usuario.Domain.Services.ValidatorService;
    using Usuario.Host.ApplicationServices;
    using Usuario.Infrastructure.Builders;
    using Usuario.Infrastructure.EntityFrameworkCore;
    using Usuario.Infrastructure.Repositories;
    using Usuario.Infrastructure.Repositories.Read;

    var builder = WebApplication.CreateBuilder(args);
    
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers(); 
    
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost", builder => builder
            .WithOrigins("http://127.0.0.1:5500", "http://localhost:5500") 
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()); 
    });
    
    builder.Services.AddHttpClient();
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
    builder.Services.AddHttpClient<IUsuarioAleatorioAppService, UsuarioAleatorioAppService>();
    builder.Services.AddTransient<IUsuarioService, UsuarioService>();
    builder.Services.AddTransient<IUsuarioValidatorService, UsuarioValidatorService>();
    builder.Services.AddTransient<IUsuarioAleatorioAppService, UsuarioAleatorioAppService>();
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

    IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseCors("AllowLocalhost"); 

    app.UseHttpsRedirection();
    app.MapControllers(); 
    app.Run();