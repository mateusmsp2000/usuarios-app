using Usuario.Commands;
using Usuario.Domain.Enums;
using Usuario.Domain.Localizacoes;
using Usuario.Domain.Services.ValidatorService;

namespace Usuario.Domain;

public class Usuario
{
    public Guid Id { get; set; } 
    public string PrimeiroNome { get; set; } 
    public string UltimoNome { get; set; } 
    public string Email { get; set; } 
    public DateTime DataNascimento { get; set; } 
    public string Genero { get; set; } 
    public string Telefone { get; set; } 
    public List<Localizacao> Localizacoes { get; init; } = new List<Localizacao>();

    public InserirUsuarioValidacaoEnum Inserir(InserirUsuarioCommand comando, IUsuarioValidatorService usuarioValidatorService)
    {
        var resultadoValidacao = usuarioValidatorService.ValidarInsercao(comando);
        if (resultadoValidacao != InserirUsuarioValidacaoEnum.Ok)
        {
            return resultadoValidacao;
        }
        Id = Guid.NewGuid();
        Email = comando.Email;
        Genero = comando.Genero;
        DataNascimento = comando.DataNascimento;
        PrimeiroNome = comando.PrimeiroNome;
        Telefone = comando.Telefone;
        UltimoNome = comando.UltimoNome;
        foreach (var localizacaoInserir in comando.Localizacoes)
        {
            var localizacao = new Localizacao();
            localizacao.Inserir(Id, localizacaoInserir);
            Localizacoes.Add(localizacao);
        }

        return resultadoValidacao;
    }
    
    public AtualizarUsuarioValidacaoEnum Atualizar(AtualizarUsuarioCommand comando, IUsuarioValidatorService usuarioValidatorService)
    {
        var resultadoValidacao = usuarioValidatorService.ValidarAtualizacao(comando);
        if (resultadoValidacao != AtualizarUsuarioValidacaoEnum.Ok)
        {
            return resultadoValidacao;
        }
        Email = comando.Email;
        Genero = comando.Genero;
        DataNascimento = comando.DataNascimento;
        PrimeiroNome = comando.PrimeiroNome;
        Telefone = comando.Telefone;
        UltimoNome = comando.UltimoNome;
        foreach (var localizacaoComando in comando.Localizacoes)
        {
            var localizacaoAtualizar = Localizacoes.FirstOrDefault(l => l.Id == localizacaoComando.Id);
            localizacaoAtualizar.Atualizar(Id, localizacaoComando);
        }

        return resultadoValidacao;
    }
}