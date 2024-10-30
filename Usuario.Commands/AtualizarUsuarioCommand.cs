using Usuario.Commands.Localizacoes;

namespace Usuario.Commands;

public class AtualizarUsuarioCommand
{
    public Guid Id { get; set; } 
    public string PrimeiroNome { get; set; } 
    public string UltimoNome { get; set; } 
    public string Email { get; set; } 
    public DateTime DataNascimento { get; set; } 
    public string Genero { get; set; } 
    public string Telefone { get; set; } 
    public List<AtualizarLocalizacaoCommand> Localizacoes { get; set; } = new List<AtualizarLocalizacaoCommand>();

}