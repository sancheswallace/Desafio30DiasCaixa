using MinhaApi.Models;

namespace MinhaApi.Data;

public class ProdutoRepository
{
    private readonly List<Produto> _produtos = new()
    {
        new Produto(1, "Mouse", 50),
        new Produto(2, "Teclado", 120),
        new Produto(3, "Monitor", 500)
    };

    public List<Produto> Listar() => _produtos;

    public Produto? BuscarPorId(int id) =>
        _produtos.FirstOrDefault(p => p.Id == id);

    public void Adicionar(Produto produto) =>
        _produtos.Add(produto);

    public void Atualizar(int id, Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == id);
        if (index != -1)
            _produtos[index] = produto;
    }

    public void Remover(int id)
    {
        var produto = BuscarPorId(id);
        if (produto is not null)
            _produtos.Remove(produto);
    }
}
