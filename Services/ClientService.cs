using System.Collections.Generic;
using System.Threading.Tasks;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories.Interfaces;

namespace Unity_Of_Work
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _uow;

        public ClientService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<Notificator> CreateClient(ClientViewModel clientViewModel)
        {
            _uow.ClientRepository.Add(new Client(clientViewModel));
            _uow.Commit();
            return Task.FromResult(Notificator.OK("Cliente cadastrado com sucesso"));
        }
        public Task<Notificator> RemoveClient(ClientViewModel clientViewModel)
        {
            _uow.ClientRepository.Delete(new Client(clientViewModel));
            _uow.Commit();
            return Task.FromResult(Notificator.OK("Cliente removido com Sucesso"));
        }
        public Task<bool> UpdateCliente(ClientViewModel clientViewModel)
        {
            _uow.ClientRepository.Update(new Client(clientViewModel));
            _uow.Commit();
            return Task.FromResult(true);
        }
        public Task<IEnumerable<Client>> GetAllClients()
        {
            var result = _uow.ClientRepository.Get();
            return Task.FromResult(result);
        }
        public  Task<Client> GetClientById(int id)
        {
            var result = _uow.ClientRepository.GetById(c => c.ClientId == id);
            return Task.FromResult(result);
        }
    }
}
