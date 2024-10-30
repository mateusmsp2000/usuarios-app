using Usuario.Commands;
using Usuario.Domain.Enums;

namespace Usuario.Domain.Services.ValidatorService;

public class UsuarioValidatorService : IUsuarioValidatorService
{
    public InserirUsuarioValidacaoEnum ValidarInsercao(InserirUsuarioCommand comando)
    {
        if (string.IsNullOrEmpty(comando.PrimeiroNome))
        {
            return InserirUsuarioValidacaoEnum.NomeObrigatorio;
        }

        if (string.IsNullOrEmpty(comando.UltimoNome))
        {
            return InserirUsuarioValidacaoEnum.UltimoNomeObrigatorio;
        }

        return InserirUsuarioValidacaoEnum.Ok;
    }
    
    public AtualizarUsuarioValidacaoEnum ValidarAtualizacao(AtualizarUsuarioCommand comando)
    {
        if (string.IsNullOrEmpty(comando.PrimeiroNome))
        {
            return AtualizarUsuarioValidacaoEnum.NomeObrigatorio;
        }

        if (string.IsNullOrEmpty(comando.UltimoNome))
        {
            return AtualizarUsuarioValidacaoEnum.UltimoNomeObrigatorio;
        }

        return AtualizarUsuarioValidacaoEnum.Ok;
    }
}