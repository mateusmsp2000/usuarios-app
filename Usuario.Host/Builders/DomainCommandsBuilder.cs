using Usuario.Commands;
using Usuario.Commands.Localizacoes;
using Usuario.Host.DTOs;

namespace Usuario.Host.Builders;

public static class DomainCommandsBuilder
{
    public static InserirUsuarioCommand BuildInserirUsuarioCommand(InserirUsuarioInput input)
    {
        var localizacoesCommand = new List<InserirLocalizacaoCommand>();
        foreach (var localizacao in input.Localizacoes)
        {
            localizacoesCommand.Add(new InserirLocalizacaoCommand()
            {
                Id = localizacao.Id,
                Cidade = localizacao.Cidade,
                IdUsuario = localizacao.IdUsuario,
                Pais = localizacao.Pais,
            });
        }
        
        return new InserirUsuarioCommand()
        {
            Email = input.Email,
            Localizacoes = localizacoesCommand,
            DataNascimento = input.DataNascimento,
            PrimeiroNome = input.PrimeiroNome,
            UltimoNome = input.UltimoNome,
            Genero = input.Genero,
            Id = input.Id,
            Telefone = input.Telefone,
        };
    } 
    
    public static AtualizarUsuarioCommand BuildAtualizarUsuarioCommand(AtualizarUsuarioInput input)
    {
        var localizacoesCommand = new List<AtualizarLocalizacaoCommand>();
        foreach (var localizacao in input.Localizacoes)
        {
            localizacoesCommand.Add(new AtualizarLocalizacaoCommand()
            {
                Id = localizacao.Id,
                Cidade = localizacao.Cidade,
                IdUsuario = localizacao.IdUsuario,
                Pais = localizacao.Pais,
            });
        }
        
        return new AtualizarUsuarioCommand()
        {
            Email = input.Email,
            Localizacoes = localizacoesCommand,
            DataNascimento = input.DataNascimento,
            PrimeiroNome = input.PrimeiroNome,
            UltimoNome = input.UltimoNome,
            Genero = input.Genero,
            Id = input.Id,
            Telefone = input.Telefone,
        };
    } 
}