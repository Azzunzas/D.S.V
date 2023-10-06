using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Restaurante.Data;
using Restaurante.Models;

namespace Restaurante.Controllers;
[ApiController]
[Route("[Controller]")]

public class MesasController : Controller
{
    private readonly SistemaRestauranteDBContext _dbContext;
    public MesasController(SistemaRestauranteDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("CadastroMesas")]
    public async Task<ActionResult> Cadastrar(Mesas mesas)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Mesas is null) return NotFound();
        await _dbContext.AddAsync(mesas);
        await _dbContext.SaveChangesAsync();
        return Created("", mesas);
    }

    [HttpGet]
    [Route("MostrarMesas")]
    public async Task<ActionResult<IEnumerable<Mesas>>> ListarM()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Mesas is null) return NotFound();
        return await _dbContext.Mesas.ToListAsync();
    }

    [HttpGet]
    [Route("BuscarMesa")]
    public async Task<ActionResult<Mesas>> BuscarB(int id)
    {
        if (id == 0) return NotFound();
        if (_dbContext.Mesas is null) return NotFound();
        var Nummesa = await _dbContext.Mesas.FindAsync(id);
        if (Nummesa == null) return NotFound();
        return Nummesa;
    }
    
    [HttpPatch]
    [Route("Alterar/{status}")]
    public async Task<ActionResult> MudarDescricao(int id, string status)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Mesas is null) return NotFound();
        var Smesas = await _dbContext.Mesas.FindAsync(id);
        if (Smesas == null) return NotFound();
        Smesas.Status = status;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public async Task<ActionResult> ExcluirP(int id)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Mesas is null) return NotFound();
        var ExMesa = await _dbContext.Mesas.FindAsync(id);
        if (ExMesa == null) return NotFound();
    
        _dbContext.Mesas.Remove(ExMesa);
    
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}