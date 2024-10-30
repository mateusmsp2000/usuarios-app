using Usuario.Infrastructure.Commands;
using Usuario.Infrastructure.Models.Localizacoes;

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

    public void Inserir(InserirUsuarioCommand comando)
    {
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
    }
    
    public void Atualizar(AtualizarUsuarioCommand comando)
    {
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
    }
}