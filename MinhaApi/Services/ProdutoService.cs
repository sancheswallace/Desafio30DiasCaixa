using System.Diagnostics;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Telemetry;

namespace MinhaApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repo;

    public ProdutoService(IProdutoRepository repo)
    {
        _repo = repo;
    }

    public Produto? ObterPorId(int id)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoService.ObterPorId", ActivityKind.Internal);
        return _repo.BuscarPorId(id);
    }

    public IEnumerable<Produto> Listar()
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoService.Listar", ActivityKind.Internal);
        return _repo.Listar();
    }

    public void Criar(Produto produto)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoService.Criar", ActivityKind.Internal);
        _repo.Adicionar(produto);
    }

    public void Atualizar(int id, Produto produto)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoService.Atualizar", ActivityKind.Internal);
        _repo.Atualizar(id, produto);
    }

    public void Remover(int id)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoService.Remover", ActivityKind.Internal);
        _repo.Remover(id);
    }
}
