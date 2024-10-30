namespace Usuario.Infrastructure.Repositories.Read;

public interface IUsuarioReadRepository
{
    Task<List<Domain.Usuario>> BuscarTodos();
    Task<Domain.Usuario> BuscarPorId(Guid id);
}