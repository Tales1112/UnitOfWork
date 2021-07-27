using System.Collections.Generic;
using System.Threading.Tasks;
using Unity_Of_Work.Models;

namespace Unity_Of_Work
{
    public interface IClientService
    {
        Task<Notificator> CreateClient(ClientViewModel clientViewModel);
        Task<Notificator> RemoveClient(ClientViewModel clientViewModel);
        Task<bool> UpdateCliente(ClientViewModel clientViewModel);
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetClientById(int id);
    }
}