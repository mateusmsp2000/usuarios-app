namespace Usuario.Host.Localizacao.DTOs;

public class AtualizarLocalizacaoInput
{
    public Guid Id { get; set; } 
    public string Cidade { get; set; } 
    public string Pais { get; set; }
    public Guid IdUsuario { get; set; }
}