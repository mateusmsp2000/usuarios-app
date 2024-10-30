using Usuario.Domain;

namespace Usuario.Infrastructure.Repositories;

public interface IUsuarioRepository
{
    Task<Domain.Usuario> Inserir(Domain.Usuario usuario);
    Task Atualizar(Domain.Usuario usuario);
    Task Excluir(Guid id);
}