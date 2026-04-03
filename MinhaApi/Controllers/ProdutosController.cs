using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private static readonly List<Produto> _produtos = new()
    {
        new Produto(1, "Mouse", 50),
        new Produto(2, "Teclado", 120)
    };

    [HttpGet]
    public IActionResult Get() => Ok(_produtos);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        return produto is null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public IActionResult Post(Produto produto)
    {
        _produtos.Add(produto);
        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == id);
        if (index == -1)
            return NotFound();

        _produtos[index] = produto;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto is null)
            return NotFound();

        _produtos.Remove(produto);
        return NoContent();
    }
}

public record Produto(int Id, string Nome, decimal Preco);
