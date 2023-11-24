using Restaurante.Models;
using Restaurante.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Restaurante.Controllers;

[ApiController]
[Route("[Controller]")]

public class UsuarioController : Controller
{
    private readonly SistemaRestauranteDBContext _dbContext;
    public UsuarioController(SistemaRestauranteDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("cadastroCliente")]
    public async Task<ActionResult> Cadastrar(Usuario usuario)
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Usuarios is null) return NotFound();
        await _dbContext.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();
        return Created("", usuario);
    }

    [HttpGet]
    [Route("MostrarClientes")]
    public async Task<ActionResult<IEnumerable<Usuario>>> Listar()
    {
        if (_dbContext is null) return NotFound();
        if (_dbContext.Usuarios is null) return NotFound();
        return await _dbContext.Usuarios.ToListAsync();
    }

    [HttpGet]
    [Route("BuscarCliente")]
    public async Task<ActionResult<Usuario>> Buscar(int id)
    {
        if (id == 0) return NotFound();
        if (_dbContext.Usuarios is null) return NotFound();
        var UsuarioId = await _dbContext.Usuarios.FindAsync(id);
        if (UsuarioId == null) return NotFound();
        return UsuarioId;
    }

    [HttpPatch]
    [Route("Alterar/{id}")]
    public async Task<ActionResult> MudarEmail(int id, string email)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Usuarios is null) return NotFound();
        var Eusuario = await _dbContext.Usuarios.FindAsync(id);
        if (Eusuario == null) return NotFound();
        Eusuario.Email = email;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public async Task<ActionResult> ExcluirUS(int id)
    {
        if (_dbContext == null) return NotFound();
        if (_dbContext.Usuarios is null) return NotFound();
        var ExUser = await _dbContext.Usuarios.FindAsync(id);
        if (ExUser == null) return NotFound();
    
        _dbContext.Usuarios.Remove(ExUser);
    
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}