namespace Usuario.Commands.Localizacoes;

public class InserirLocalizacaoCommand
{
    public Guid Id { get; set; } 
    public string Cidade { get; set; } 
    public string Pais { get; set; }
    
    public Guid IdUsuario { get; set; }
}