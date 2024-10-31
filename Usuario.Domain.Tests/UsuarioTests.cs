using Moq;
using Usuario.Commands;
using Usuario.Domain.Enums;
using Usuario.Domain.Services.ValidatorService;

namespace Usuario.Domain.Tests;

public class UsuarioTests
{
    [Theory]
    [InlineData("João", "Silva", "joao@teste.com", "Masculino", "123456789", "2020-01-01", InserirUsuarioValidacaoEnum.Ok)]
    [InlineData("", "Silva", "joao@teste.com", "Masculino", "123456789", "2020-01-01", InserirUsuarioValidacaoEnum.NomeObrigatorio)]
    [InlineData("João", "", "joao@teste.com", "Masculino", "123456789", "2020-01-01", InserirUsuarioValidacaoEnum.UltimoNomeObrigatorio)]
    public void InserirUsuario_TesteVariosCenarios(string primeiroNome, string ultimoNome, string email, string genero, string telefone, string dataNascimentoStr, InserirUsuarioValidacaoEnum esperado)
    {
        var usuario = new Usuario();
        var usuarioValidatorService = new Mock<IUsuarioValidatorService>();
        usuarioValidatorService.Setup(s => s.ValidarInsercao(It.IsAny<InserirUsuarioCommand>()))
            .Returns(esperado);

        var usuarioComando = new InserirUsuarioCommand()
        {
            PrimeiroNome = primeiroNome,
            UltimoNome = ultimoNome,
            Email = email,
            Genero = genero,
            Telefone = telefone,
            DataNascimento = DateTime.Parse(dataNascimentoStr),
        };
        
        var resultadoValidacao = usuario.Inserir(usuarioComando, usuarioValidatorService.Object);
        Assert.Equal(esperado, resultadoValidacao);
    }
    
    [Theory]
    [InlineData("João", "Silva", "joao@teste.com", "Masculino", "123456789", "2020-01-01", AtualizarUsuarioValidacaoEnum.Ok)]
    [InlineData("", "Silva", "joao@teste.com", "Masculino", "123456789", "2020-01-01", AtualizarUsuarioValidacaoEnum.NomeObrigatorio)]
    [InlineData("João", "", "joao@teste.com", "Masculino", "123456789", "2020-01-01", AtualizarUsuarioValidacaoEnum.UltimoNomeObrigatorio)]
    public void AtualizarUsuario_TesteVariosCenarios(string primeiroNome, string ultimoNome, string email, string genero, string telefone, string dataNascimentoStr, AtualizarUsuarioValidacaoEnum esperado)
    {
        var usuario = new Usuario();
        var usuarioValidatorService = new Mock<IUsuarioValidatorService>();
        usuarioValidatorService.Setup(s => s.ValidarAtualizacao(It.IsAny<AtualizarUsuarioCommand>()))
            .Returns(esperado);

        var usuarioComando = new AtualizarUsuarioCommand()
        {
            PrimeiroNome = primeiroNome,
            UltimoNome = ultimoNome,
            Email = email,
            Genero = genero,
            Telefone = telefone,
            DataNascimento = DateTime.Parse(dataNascimentoStr),
        };
        
        var resultadoValidacao = usuario.Atualizar(usuarioComando, usuarioValidatorService.Object);
        Assert.Equal(esperado, resultadoValidacao);
    }
}