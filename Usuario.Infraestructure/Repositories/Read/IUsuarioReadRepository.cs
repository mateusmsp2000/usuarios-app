namespace Usuario.Infrastructure.Repositories.Read;

public interface IUsuarioReadRepository
{
    Task<List<Domain.Usuario>> BuscarTodos(int page, int pageSize);
    Task<Domain.Usuario> BuscarPorId(Guid id);
}