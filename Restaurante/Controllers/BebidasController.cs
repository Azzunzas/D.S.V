using Restaurante.Models;
using Restaurante.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Restaurante.Controllers;

[ApiController]
[Route("[Controller]")]

public class BebidasController : Controller
{
    private readonly SistemaRestauranteDBContext _dbContext;
    public BebidasController(SistemaRestauranteDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastroBebidas")]
    public async Task<ActionResult> Cadastrar(Bebidas bebidas)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Bebidas is null) return NotFound();
        await _dbContext.AddAsync(bebidas);
        await _dbContext.SaveChangesAsync();
        return Created("", bebidas);
    }
    [HttpGet]
    [Route("MostrarBebidas")]
    public async Task<ActionResult<IEnumerable<Bebidas>>> ListarB()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Bebidas is null) return NotFound();
        return await _dbContext.Bebidas.ToListAsync();
    }
    [HttpGet]
    [Route("BuscarBebida")]
    public async Task<ActionResult<Bebidas>> BuscarB(int id)
    {
        if (id == 0) return NotFound();
        if (_dbContext.Bebidas is null) return NotFound();
        var Benome = await _dbContext.Bebidas.FindAsync(id);
        if (Benome == null) return NotFound();
        return Benome;
    }
    [HttpPut]
    [Route("AlterarBebidas")]
    public async Task<ActionResult> AlterarB(Bebidas bebidas)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Bebidas is null) return NotFound();
        var altbeb = await _dbContext.Bebidas.FindAsync(bebidas.Nome);
        if (altbeb is null) return NotFound();
        _dbContext.Bebidas.Update(bebidas);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch]
    [Route("Alterar/{id}")]
    public async Task<ActionResult> MudarDescricao(int id, string descricao)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Bebidas is null) return NotFound();
        var Dbebi = await _dbContext.Bebidas.FindAsync(id);
        if (Dbebi == null) return NotFound();
        Dbebi.Descricao = descricao;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
