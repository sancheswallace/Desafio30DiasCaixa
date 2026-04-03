using Microsoft.AspNetCore.Mvc;
using MinhaApi.Data;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteRepository _repo;

    public ClientesController(ClienteRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var clientes = _repo.Listar();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cliente = _repo.BuscarPorId(id);
        return cliente is null ? NotFound() : Ok(cliente);
    }

    [HttpPost]
    public IActionResult Post(Cliente cliente)
    {
        _repo.Adicionar(cliente);
        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Cliente cliente)
    {
        var existente = _repo.BuscarPorId(id);
        if (existente is null)
            return NotFound();

        _repo.Atualizar(id, cliente);
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
