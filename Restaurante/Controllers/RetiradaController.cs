using Restaurante.Models;
using Restaurante.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Restaurante.Controllers;

[ApiController]
[Route("[Controller]")]

public class RetiradaController : Controller
{
    private readonly SistemaRestauranteDBContext _dbContext;

    public RetiradaController(SistemaRestauranteDBContext dbContext)    
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("CadastroRetirada")]
    public async Task<ActionResult> Cadastrar(Retirada retirada)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Retirada is null) return NotFound();
        await _dbContext.AddAsync(retirada);
        await _dbContext.SaveChangesAsync();
        return Created("", retirada);
    }

    [HttpGet]
    [Route("MostrarRetirada")]
    public async Task<ActionResult<IEnumerable<Retirada>>> ListarR()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Retirada is null) return NotFound();
        return await _dbContext.Retirada.ToListAsync();
    }

    [HttpGet]
    [Route("BuscarRetirada")]
    public async Task<ActionResult<Retirada>> BuscarR(int id)
    {
        if (id == 0) return NotFound();
        if (_dbContext.Retirada is null) return NotFound();
        var RetiraNome = await _dbContext.Retirada.FindAsync(id);
        if (RetiraNome == null) return NotFound();
        return RetiraNome;
    }

    [HttpPut]
    [Route("AlterarRetirada")]
    public async Task<ActionResult> AlterarR(Retirada retirada)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Retirada is null) return NotFound();
        var AltStatusRetirada = await _dbContext.Retirada.FindAsync(retirada.Status);
        if (AltStatusRetirada is null) return NotFound();
        _dbContext.Retirada.Update(retirada);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("Alterar/{id}")]
    public async Task<ActionResult> MudarId(int id, int pedido)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Retirada is null) return NotFound();
        var NumPedidoRetirada = await _dbContext.Retirada.FindAsync(pedido);
        if (NumPedidoRetirada == null) return NotFound();
        NumPedidoRetirada.NumPedido = pedido;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}