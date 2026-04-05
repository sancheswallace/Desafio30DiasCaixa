namespace MinhaApi.Services;

using MinhaApi.Models;

public interface IClienteService
{
    Cliente? ObterPorId(int id);
    IEnumerable<Cliente> Listar();
    void Criar(Cliente cliente);
    void Atualizar(int id, Cliente cliente);
    void Remover(int id);
}
