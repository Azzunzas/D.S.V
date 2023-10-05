using Restaurante.Models;
using Restaurante.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Restaurante.Controllers;

[ApiController]
[Route("[Controller]")]

public class VeiculosController : Controller
{
    private readonly SistemaRestauranteDBContext _dbContext;
    public VeiculosController(SistemaRestauranteDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("CadatroVeiculos")]
    public async Task<ActionResult> Cadastrar(Veiculos veiculos)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Veiculos is null) return NotFound();
        await _dbContext.AddAsync(veiculos);
        await _dbContext.SaveChangesAsync();
        return Created("", veiculos);
    }
    [HttpGet]
    [Route("MostrarVeiculos")]
    public async Task<ActionResult<IEnumerable<Veiculos>>> ListarV()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Veiculos is null) return NotFound();
        return await _dbContext.Veiculos.ToListAsync();
    }
    [HttpGet]
    [Route("BuscarVeiculo")]
    public async Task<ActionResult<Veiculos>> BuscarV(string placa)
    {
        if (placa == null) return NotFound();
        if (_dbContext.Veiculos is null) return NotFound();
        var Vplaca = await _dbContext.Veiculos.FindAsync(placa);
        if (Vplaca == null) return NotFound();
        return Vplaca;
    }
    [HttpPut]
    [Route("AlterarVeiculos")]
    public async Task<ActionResult> AlterarV(Veiculos veiculos)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Veiculos is null) return NotFound();
        var altvei = await _dbContext.Veiculos.FindAsync(veiculos.Placa);
        if (altvei is null) return NotFound();
        _dbContext.Veiculos.Update(veiculos);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch]
    [Route("Alterar/{id}")]
    public async Task<ActionResult> MudarSenha(int id, string password)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Funcionarios is null) return NotFound();
        var Sfunciona = await _dbContext.Funcionarios.FindAsync(id);
        if (Sfunciona == null) return NotFound();
        Sfunciona.Password = password;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch]
    [Route("Alterardescricao/{id}")]
    public async Task<ActionResult> MudarDescricaoVeiculo(int id, string descricao)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Veiculos is null) return NotFound();
        var Dveiculo = await _dbContext.Veiculos.FindAsync(id);
        if (Dveiculo == null) return NotFound();
        Dveiculo.Descricao = descricao;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}
