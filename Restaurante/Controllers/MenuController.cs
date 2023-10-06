using Microsoft.AspNetCore.Mvc;
using Restaurante.Data;

namespace Restaurante.Controllers;

[ApiController]
[Route("[Controller]")]
public class MenuController : ControllerBase
{
    private readonly SistemaRestauranteDBContext _dbContext;

    public MenuController(SistemaRestauranteDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("pratos")]
    public IActionResult GetPratos()
    {
        var pratos = _dbContext.Pratos.ToList();
        return Ok(pratos);
    }

    [HttpGet("bebidas")]
    public IActionResult GetBebidas()
    {
        var bebidas = _dbContext.Bebidas.ToList();
        return Ok(bebidas);
    }
}
