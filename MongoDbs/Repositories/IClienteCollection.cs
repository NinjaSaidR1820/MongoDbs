using MongoDbs.Models;

namespace MongoDbs.Repositories
{
    public interface IClienteCollection
    {
        Task InsertCliente(Clientes Cliente);
        Task UpdateCliente(Clientes Cliente);
        Task DeleteCliente(string Id);
        Task<Clientes> GetClienteById(string Id);  
        Task<List<Clientes>> GetAllClientes();
        


    }
}
