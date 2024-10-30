using Usuario.Commands.Localizacoes;

namespace Usuario.Commands;

public class InserirUsuarioCommand
{
    public Guid Id { get; set; } 
    public string PrimeiroNome { get; set; } 
    public string UltimoNome { get; set; } 
    public string Email { get; set; } 
    public DateTime DataNascimento { get; set; } 
    public string Genero { get; set; } 
    public string Telefone { get; set; } 
    public List<InserirLocalizacaoCommand> Localizacoes { get; set; } = new List<InserirLocalizacaoCommand>();

}