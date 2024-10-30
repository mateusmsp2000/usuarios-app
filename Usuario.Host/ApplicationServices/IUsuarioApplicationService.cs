using Usuario.Host.ApplicationServices.DTOs;

namespace Usuario.Host.ApplicationServices;

public interface IUsuarioApplicationService
{
    Task<UsuarioAleatorioDto.UsuarioDto?> ObterUsuarioAleatorio();
}