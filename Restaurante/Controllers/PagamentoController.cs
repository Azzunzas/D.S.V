using Restaurante.Models;
using Restaurante.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Restaurante.Controllers;

[Route("api/pagamentos")]
[ApiController]
public class PagamentosController : ControllerBase
{
    private List<PagamentoCartao> cartaoPagamentos = new List<PagamentoCartao>();

    // GET: api/pagamentos/cartao
    [HttpGet]
    [Route("cartao")]
    public IActionResult GetCartaoPagamentos()
    {
        return Ok(cartaoPagamentos);
    }

    // POST: api/pagamentos/cartao
    [HttpPost]
    [Route("cartao")]
    public IActionResult AddCartaoPagamento([FromBody] PagamentoCartao pagamento)
    {
        cartaoPagamentos.Add(pagamento);
        return CreatedAtAction(nameof(GetCartaoPagamentos), new { id = pagamento.Id }, pagamento);
    }

    // PUT: api/pagamentos/cartao/{id}
    [HttpPut]
    [Route("cartao/{id}")]
    public IActionResult UpdateCartaoPagamento(int id, [FromBody] PagamentoCartao pagamento)
    {
        var existingPagamento = cartaoPagamentos.Find(p => p.Id == id);
        if (existingPagamento == null)
        {
            return NotFound();
        }

        // Atualize os dados do pagamento existente com os novos dados do pagamento
        existingPagamento.NomeDoDono = pagamento.NomeDoDono;
        existingPagamento.NumCartao = pagamento.NumCartao;
        existingPagamento.Bandeira = pagamento.Bandeira;

        return NoContent();
    }

    // DELETE: api/pagamentos/cartao/{id}
    [HttpDelete]
    [Route("cartao/{id}")]
    public IActionResult DeleteCartaoPagamento(int id)
    {
        var existingPagamento = cartaoPagamentos.Find(p => p.Id == id);
        if (existingPagamento == null)
        {
            return NotFound();
        }

        cartaoPagamentos.Remove(existingPagamento);
        return NoContent();
    }
}

public class PagamentoCartao
{
    public int Id { get; set; }
    public string? NomeDoDono { get; set; }
    public long NumCartao { get; set; }
    public string? Bandeira { get; set; }
}