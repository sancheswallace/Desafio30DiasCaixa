using System.Diagnostics;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Telemetry;

namespace MinhaApi.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repo;

    public ClienteService(IClienteRepository repo)
    {
        _repo = repo;
    }

    public Cliente? ObterPorId(int id)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteService.ObterPorId", ActivityKind.Internal);
        return _repo.BuscarPorId(id);
    }

    public IEnumerable<Cliente> Listar()
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteService.Listar", ActivityKind.Internal);
        return _repo.Listar();
    }

    public void Criar(Cliente cliente)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteService.Criar", ActivityKind.Internal);
        _repo.Adicionar(cliente);
    }

    public void Atualizar(int id, Cliente cliente)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteService.Atualizar", ActivityKind.Internal);
        _repo.Atualizar(id, cliente);
    }

    public void Remover(int id)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ClienteService.Remover", ActivityKind.Internal);
        _repo.Remover(id);
    }
}
