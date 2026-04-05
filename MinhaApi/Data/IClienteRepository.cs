using MinhaApi.Models;

namespace MinhaApi.Data;

public interface IClienteRepository
{
    IEnumerable<Cliente> Listar();
    Cliente? BuscarPorId(int id);
    void Adicionar(Cliente cliente);
    void Atualizar(int id, Cliente cliente);
    void Remover(int id);
}
