using System.Text.Json.Serialization;
using Usuario.Infrastructure.Models.Localizacoes.Commands;

namespace Usuario.Infrastructure.Models.Localizacoes;

public class Localizacao
{
    public Guid Id { get; set; } 
    public string Cidade { get; set; } 
    public string Pais { get; set; }
    
    public Guid IdUsuario { get; set; }
    
    [JsonIgnore]
    public Domain.Usuario Usuario { get; set; }

    public void Inserir(Guid idUsuario, InserirLocalizacaoCommand comando)
    {
        Id = Guid.NewGuid();
        IdUsuario = idUsuario;
        Cidade = comando.Cidade;
        Pais = comando.Pais;
    }
    
    public void Atualizar(Guid idUsuario, AtualizarLocalizacaoCommand comando)
    {
        IdUsuario = idUsuario;
        Cidade = comando.Cidade;
        Pais = comando.Pais;
    }
}