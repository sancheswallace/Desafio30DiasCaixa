using Microsoft.AspNetCore.Mvc;
using MinhaApi.Data;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoRepository _repo;

    public ProdutosController(ProdutoRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var produtos = _repo.Listar();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = _repo.BuscarPorId(id);
        return produto is null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public IActionResult Post(Produto produto)
    {
        _repo.Adicionar(produto);
        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Produto produto)
    {
        var existente = _repo.BuscarPorId(id);
        if (existente is null)
            return NotFound();

        _repo.Atualizar(id, produto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existente = _repo.BuscarPorId(id);
        if (existente is null)
            return NotFound();

        _repo.Remover(id);
        return NoContent();
    }
}
