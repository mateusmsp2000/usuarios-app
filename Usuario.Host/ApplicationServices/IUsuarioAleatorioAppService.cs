using Usuario.Host.ApplicationServices.DTOs;

namespace Usuario.Host.ApplicationServices;

public interface IUsuarioAleatorioAppService
{
    Task<UsuarioAleatorioDto.UsuarioDto?> ObterUsuarioAleatorio();
}