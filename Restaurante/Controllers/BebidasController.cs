using Restaurante.Models;
using Restaurante.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Restaurante.Controllers;

[ApiController]
[Route("[Controller]")]

public class BebidaController : Controller
{
    private readonly SistemaRestauranteDBContext _dbContext;
    public BebidaController(SistemaRestauranteDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastroBebidas")]
    public async Task<ActionResult> Cadastrar(Bebida bebidas)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Bebidas is null) return NotFound();
        await _dbContext.AddAsync(bebidas);
        await _dbContext.SaveChangesAsync();
        return Created("", bebidas);
    }
    
    [HttpGet]
    [Route("MostrarBebidas")]
    public async Task<ActionResult<IEnumerable<Bebida>>> ListarB()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Bebidas is null) return NotFound();
        return await _dbContext.Bebidas.ToListAsync();
    }

    [HttpGet]
    [Route("BuscarBebida")]
    public async Task<ActionResult<Bebida>> BuscarB(int id)
    {
        if (id == 0) return NotFound();
        if (_dbContext.Bebidas is null) return NotFound();
        var Benome = await _dbContext.Bebidas.FindAsync(id);
        if (Benome == null) return NotFound();
        return Benome;
    }

    [HttpPut]
    [Route("AlterarBebidas")]
    public async Task<ActionResult> AlterarB(int id, Bebida bebidas)
    {
        var AltBebida = await _dbContext.Bebidas.FindAsync(id);
        if (AltBebida == null) return NotFound();

        AltBebida.Nome = bebidas.Nome;
        AltBebida.Descricao = bebidas.Descricao;
        AltBebida.Preco = bebidas.Preco;

        _dbContext.Bebidas.Update(AltBebida);
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