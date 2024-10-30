using Usuario.Infrastructure.Commands;

namespace Usuario.Domain.Services;

public interface IUsuarioService
{
    Task Adicionar(InserirUsuarioCommand comando);
    Task Atualizar(AtualizarUsuarioCommand comando);
    Task Remover(Guid id);
}