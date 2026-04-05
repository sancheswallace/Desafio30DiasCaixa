using MinhaApi.Data;
using MinhaApi.Models;

namespace MinhaApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repo;

    public ProdutoService(IProdutoRepository repo)
    {
        _repo = repo;
    }

    public Produto? ObterPorId(int id) => _repo.BuscarPorId(id);

    public IEnumerable<Produto> Listar() => _repo.Listar();

    public void Criar(Produto produto) => _repo.Adicionar(produto);

    public void Atualizar(int id, Produto produto) => _repo.Atualizar(id, produto);

    public void Remover(int id) => _repo.Remover(id);
}
