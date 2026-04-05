using MinhaApi.Models;

namespace MinhaApi.Data;

public interface IProdutoRepository
{
    IEnumerable<Produto> Listar();
    Produto? BuscarPorId(int id);
    void Adicionar(Produto produto);
    void Atualizar(int id, Produto produto);
    void Remover(int id);
}
