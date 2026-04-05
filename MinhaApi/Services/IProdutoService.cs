namespace MinhaApi.Services;

using MinhaApi.Models;

public interface IProdutoService
{
    Produto? ObterPorId(int id);
    IEnumerable<Produto> Listar();
    void Criar(Produto produto);
    void Atualizar(int id, Produto produto);
    void Remover(int id);
}
