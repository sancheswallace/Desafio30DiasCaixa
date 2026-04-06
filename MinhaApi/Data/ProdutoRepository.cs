using System.Diagnostics;
using MinhaApi.Models;
using MinhaApi.Telemetry;

namespace MinhaApi.Data;

public class ProdutoRepository : IProdutoRepository
{
    private readonly List<Produto> _produtos = new()
    {
        new Produto(1, "Mouse", 50),
        new Produto(2, "Teclado", 120),
        new Produto(3, "Monitor", 500)
    };

    public IEnumerable<Produto> Listar()
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoRepository.Listar", ActivityKind.Internal);
        return _produtos;
    }

    public Produto BuscarPorId(int id)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoRepository.BuscarPorId", ActivityKind.Internal);
        return _produtos.First(p => p.Id == id);
    }

    public void Adicionar(Produto produto)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoRepository.Adicionar", ActivityKind.Internal);
        _produtos.Add(produto);
    }

    public void Atualizar(int id, Produto produto)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoRepository.Atualizar", ActivityKind.Internal);
        var index = _produtos.FindIndex(p => p.Id == id);
        if (index != -1)
            _produtos[index] = produto;
    }

    public void Remover(int id)
    {
        using var activity = TelemetrySources.ActivitySource.StartActivity("ProdutoRepository.Remover", ActivityKind.Internal);
        var produto = BuscarPorId(id);
        if (produto is not null)
            _produtos.Remove(produto);
    }
}
