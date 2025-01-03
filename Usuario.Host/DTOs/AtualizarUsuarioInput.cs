using Usuario.Host.Localizacao.DTOs;

namespace Usuario.Host.DTOs;

public class AtualizarUsuarioInput
{
    public Guid Id { get; set; } 
    public string PrimeiroNome { get; set; } 
    public string UltimoNome { get; set; } 
    public string Email { get; set; } 
    public DateTime DataNascimento { get; set; } 
    public string Genero { get; set; } 
    public string Telefone { get; set; } 
    public List<AtualizarLocalizacaoInput> Localizacoes { get; set; } = new List<AtualizarLocalizacaoInput>();
}