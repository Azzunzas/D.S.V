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
    public async Task<ActionResult> Cadastrar(Funcionarios funcionario)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Funcionarios is null) return NotFound();
        await _dbContext.AddAsync(funcionario);
        await _dbContext.SaveChangesAsync();
        return Created("", funcionario);
    }
    [HttpGet]
    [Route("Mostrar funcionarios")]
    public async Task<ActionResult<IEnumerable<Funcionarios>>> ListarF()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Funcionarios is null) return NotFound();
        return await _dbContext.Funcionarios.ToListAsync();
    }
    [HttpGet]
    [Route("BuscarFuncionario")]
    public async Task<ActionResult<Funcionarios>> BuscarF(int login)
    {
        if (login == 0) return NotFound();
        if (_dbContext.Funcionarios is null) return NotFound();
        var Funcilog = await _dbContext.Funcionarios.FindAsync(login);
        if (Funcilog == null) return NotFound();
        return Funcilog;
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
        await _dbContext.SaveChangesAsync();
        return Ok();

    }
}
