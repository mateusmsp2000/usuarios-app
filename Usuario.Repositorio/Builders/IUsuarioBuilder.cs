namespace Usuario.Domain.Builders;

public interface IUsuarioBuilder
{
    IUsuarioBuilder AsNoTracking();
    Task<Usuario?> Build(Guid id);
}