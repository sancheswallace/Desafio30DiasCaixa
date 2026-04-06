using System.Diagnostics;
using MinhaApi.Models;
using MinhaApi.Telemetry;

namespace MinhaApi.Data;

public class ClienteRepository : IClienteRepository
{
    private readonly List<Cliente> _clientes = new()
    {
        new Cliente(1, "João"),
        new Cliente(2, "Maria"),
        new Cliente(3, "Pedro")
    };

    public IEnumerable<Cliente> Listar()
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteRepository.Listar", ActivityKind.Internal);
        return _clientes;
    }

    public Cliente? BuscarPorId(int id)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteRepository.BuscarPorId", ActivityKind.Internal);
        return _clientes.FirstOrDefault(c => c.Id == id);
    }

    public void Adicionar(Cliente cliente)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteRepository.Adicionar", ActivityKind.Internal);
        _clientes.Add(cliente);
    }

    public void Atualizar(int id, Cliente cliente)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteRepository.Atualizar", ActivityKind.Internal);
        var index = _clientes.FindIndex(c => c.Id == id);
        if (index != -1)
            _clientes[index] = cliente;
    }

    public void Remover(int id)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteRepository.Remover", ActivityKind.Internal);
        var cliente = BuscarPorId(id);
        if (cliente is not null)
            _clientes.Remove(cliente);
    }
}
