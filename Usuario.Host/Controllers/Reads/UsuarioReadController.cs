using Microsoft.AspNetCore.Mvc;
using Usuario.Infrastructure.Repositories.Read;

namespace Usuario.Host.Controllers.Reads;

[ApiController]
[Route("api/read/[controller]")]
public class UsuarioReadController : ControllerBase
{
    private readonly IUsuarioReadRepository _usuarioReadRepository; 

    public UsuarioReadController(IUsuarioReadRepository usuarioReadRepository)
    {
        _usuarioReadRepository = usuarioReadRepository;
    }
        
    [HttpGet] // Rota: GET api/read/UsuarioRead
    public async Task<ActionResult<List<Domain.Usuario>>> ObterUsuarios()
    {
        return Ok(await _usuarioReadRepository.BuscarTodos());
    }
        
    // Rota específica para ObterUsuarioPorId
    [HttpGet("{id}")] // Rota: GET api/read/UsuarioRead/{id}
    public async Task<IActionResult> ObterUsuarioPorId(Guid id)
    {
        var usuario = await _usuarioReadRepository.BuscarPorId(id);
        if (usuario == null)
        {
            return NotFound(); // Retorna 404 se não encontrar
        }
        return Ok(usuario);
    }
}