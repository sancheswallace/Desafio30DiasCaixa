using MinhaApi.Data;
using MinhaApi.Models;

namespace MinhaApi.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repo;

    public ClienteService(IClienteRepository repo)
    {
        _repo = repo;
    }

    public Cliente? ObterPorId(int id) => _repo.BuscarPorId(id);

    public IEnumerable<Cliente> Listar() => _repo.Listar();

    public void Criar(Cliente cliente) => _repo.Adicionar(cliente);

    public void Atualizar(int id, Cliente cliente) => _repo.Atualizar(id, cliente);

    public void Remover(int id) => _repo.Remover(id);
}
