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
        
    [HttpGet] 
    public async Task<ActionResult<List<Domain.Usuario>>> BuscarTodos([FromQuery] int page = 1, int pageSize = 100)
    {
        return Ok(await _usuarioReadRepository.BuscarTodos(page, pageSize));
    }
    
    [HttpGet("{id}")] 
    public async Task<IActionResult> BuscarPorId(Guid id)
    {
        return Ok(await _usuarioReadRepository.BuscarPorId(id));
    }
}