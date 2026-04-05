using MinhaApi.Models;

namespace MinhaApi.Data;

public class ClienteRepository : IClienteRepository
{
    private readonly List<Cliente> _clientes = new()
    {
        new Cliente(1, "João"),
        new Cliente(2, "Maria"),
        new Cliente(3, "Pedro")
    };

    public IEnumerable<Cliente> Listar() => _clientes;

    public Cliente? BuscarPorId(int id) =>
        _clientes.FirstOrDefault(c => c.Id == id);

    public void Adicionar(Cliente cliente) =>
        _clientes.Add(cliente);

    public void Atualizar(int id, Cliente cliente)
    {
        var index = _clientes.FindIndex(c => c.Id == id);
        if (index != -1)
            _clientes[index] = cliente;
    }

    public void Remover(int id)
    {
        var cliente = BuscarPorId(id);
        if (cliente is not null)
            _clientes.Remove(cliente);
    }
}
