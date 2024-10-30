using Usuario.Commands;
using Usuario.Domain.Enums;

namespace Usuario.Application.Services;

public interface IUsuarioService
{
    Task<InserirUsuarioValidacaoEnum> Adicionar(InserirUsuarioCommand comando);
    Task<AtualizarUsuarioValidacaoEnum> Atualizar(AtualizarUsuarioCommand comando);
    Task Remover(Guid id);
}