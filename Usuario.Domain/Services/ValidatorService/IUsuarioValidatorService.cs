using Usuario.Commands;
using Usuario.Domain.Enums;

namespace Usuario.Domain.Services.ValidatorService;

public interface IUsuarioValidatorService
{
    InserirUsuarioValidacaoEnum ValidarInsercao(InserirUsuarioCommand comando);
    AtualizarUsuarioValidacaoEnum ValidarAtualizacao(AtualizarUsuarioCommand comando);
}