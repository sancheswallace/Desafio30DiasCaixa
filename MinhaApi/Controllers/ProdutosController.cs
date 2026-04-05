using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
using MinhaApi.Services;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var produtos = _service.Listar();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = _service.ObterPorId(id);
        return produto is null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public IActionResult Post(Produto produto)
    {
        _service.Criar(produto);
        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Produto produto)
    {
        var existente = _service.ObterPorId(id);
        if (existente is null)
            return NotFound();

        _service.Atualizar(id, produto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existente = _service.ObterPorId(id);
        if (existente is null)
            return NotFound();

        _service.Remover(id);
        return NoContent();
    }
}
