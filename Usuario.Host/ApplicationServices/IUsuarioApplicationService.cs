using Usuario.Domain.Services.DTOs;

namespace Usuario.Host.ApplicationServices;

public interface IUsuarioApplicationService
{
    Task<UsuarioAleatorioDto.UsuarioDto?> ObterUsuarioAleatorio();
}