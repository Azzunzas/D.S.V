using Restaurante.Models;
using Restaurante.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Restaurante.Controllers;

[ApiController]
[Route("[Controller]")]

public class FuncionariosController : Controller
{
    private readonly SistemaRestauranteDBContext _dbContext;
    public FuncionariosController(SistemaRestauranteDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastroFuncionario")]
    public async Task<ActionResult> Cadastrar(Funcionario funcionario)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Funcionarios is null) return NotFound();
        await _dbContext.AddAsync(funcionario);
        await _dbContext.SaveChangesAsync();
        return Created("", funcionario);
    }

    [HttpGet]
    [Route("Mostrar funcionarios")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> ListarF()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Funcionarios is null) return NotFound();
        return await _dbContext.Funcionarios.ToListAsync();
    }

    [HttpGet]
    [Route("BuscarFuncionario")]
    public async Task<ActionResult<Funcionario>> BuscarF(int id)
    {
        if (id == 0) return NotFound();
        if (_dbContext.Funcionarios is null) return NotFound();
        var FunciId = await _dbContext.Funcionarios.FindAsync(id);
        if (FunciId == null) return NotFound();
        return FunciId;
    }

    [HttpPatch]
    [Route("Alterar/{id}")]
    public async Task<ActionResult> MudarFuncao(int id, string funcao)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Funcionarios is null) return NotFound();
        var Ffunciona = await _dbContext.Funcionarios.FindAsync(id);
        if (Ffunciona == null) return NotFound();
        Ffunciona.Funcao = funcao;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public async Task<ActionResult> ExcluirF(int id)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Funcionarios is null) return NotFound();
        var Exfuncionario = await _dbContext.Funcionarios.FindAsync(id);
        if (Exfuncionario == null) return NotFound();
        
        _dbContext.Funcionarios.Remove(Exfuncionario);

        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}