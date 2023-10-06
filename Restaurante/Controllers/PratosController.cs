using Restaurante.Models;
using Restaurante.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;


namespace Restaurante.Controllers;

[ApiController]
[Route("[Controller]")]

public class PratosController : Controller
{
    private readonly SistemaRestauranteDBContext _dbContext;
    public PratosController(SistemaRestauranteDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastroPratos")]
    public async Task<ActionResult> Cadastrar(Pratos pratos)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pratos is null) return NotFound();
        await _dbContext.AddAsync(pratos);
        await _dbContext.SaveChangesAsync();
        return Created("", pratos);
    }
    [HttpGet]
    [Route("MostrarPratos")]
    public async Task<ActionResult<IEnumerable<Pratos>>> ListarP()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Pratos is null) return NotFound();
        return await _dbContext.Pratos.ToListAsync();
    }
    [HttpGet]
    [Route("BuscarPrato")]
    public async Task<ActionResult<Pratos>> BuscarP(int id)
    {
        if (id == 0) return NotFound();
        if (_dbContext.Pratos is null) return NotFound();
        var PraId = await _dbContext.Pratos.FindAsync(id);
        if (PraId == null) return NotFound();
        return PraId;
    }
    [HttpPut]
    [Route("AlterarPratos")]
    public async Task<ActionResult> AlterarP(Pratos pratos)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Pratos is null) return NotFound();
        var altprat = await _dbContext.Pratos.FindAsync(pratos.Nome);
        if (altprat is null) return NotFound();
        _dbContext.Pratos.Update(pratos);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch]
    [Route("Alterar/{id}")]
    public async Task<ActionResult> MudarPreco(int id, float preco)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Pratos is null) return NotFound();
        var Ppratos = await _dbContext.Pratos.FindAsync(id);
        if (Ppratos == null) return NotFound();
        Ppratos.Preco = preco;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete]
    [Route("deletar/{id}")]
    public async Task<ActionResult> ExcluirP(int id)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Usuarios is null) return NotFound();
        var Exprato = await _dbContext.Pratos.FindAsync(id);
        if (Exprato == null) return NotFound();
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
