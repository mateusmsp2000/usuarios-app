namespace Usuario.Infrastructure.Builders;

public interface IUsuarioBuilder
{
    IUsuarioBuilder AsNoTracking();
    Task<Domain.Usuario?> Build(Guid id);
}