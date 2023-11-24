using Microsoft.AspNetCore.Mvc;
using Restaurante.Data;
using Restaurante.Models;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<Prato>>> GetPratos()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pratos is null) return NotFound();
        return await _dbContext.Pratos.ToListAsync();
    }

    [HttpGet("bebidas")]
    public async Task<ActionResult<IEnumerable<Bebida>>> GetBebidas()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Bebidas is null) return NotFound();
        return await _dbContext.Bebidas.ToListAsync();
    }
}