using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories.Interfaces;
using Unity_Of_Work.Validators;

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
            var validator = new ClientViewModelValidator().Validate(clientViewModel);
            if (!validator.IsValid)
                return Task.FromResult(Notificator.NorOk(validator.Errors[0].ToString(), HttpStatusCode.BadRequest));
            _uow.ClientRepository.Add(new Client(clientViewModel));
            _uow.Commit();

            return Task.FromResult(Notificator.OK("Cliente cadastrado com sucesso"));
        }
        public Task<Notificator> RemoveClient(ClientViewModel clientViewModel)
        {
            var validator = new ClientViewModelValidator().Validate(clientViewModel);
            if (!validator.IsValid)
                return Task.FromResult(Notificator.NorOk(validator.Errors[0].ToString(), HttpStatusCode.BadRequest));

            _uow.ClientRepository.Delete(new Client(clientViewModel));

            _uow.Commit();
            return Task.FromResult(Notificator.OK("Cliente removido com Sucesso"));
        }
        public Task<Notificator> UpdateCliente(ClientViewModel clientViewModel)
        {
            var validator = new ClientViewModelValidator().Validate(clientViewModel);
            if (!validator.IsValid)
                return Task.FromResult(Notificator.NorOk(validator.Errors[0].ToString(), HttpStatusCode.BadRequest));

            _uow.ClientRepository.Update(new Client(clientViewModel));
            _uow.Commit();
            return Task.FromResult(Notificator.OK("Cliente atualizado com Sucesso"));
        }
        public Task<Notificator> GetAllClients()
        {
            var result = _uow.ClientRepository.Get();

            if (!result.Any() || result.FirstOrDefault() is null)
                return Task.FromResult(Notificator.NorOk("Clientes não encontrado nada base", HttpStatusCode.BadRequest));

            return Task.FromResult(Notificator.OK(result));
        }
        public Task<Notificator> GetClientById(int id)
        {
            var result = _uow.ClientRepository.GetById(c => c.ClientId == id);
            if (result == null)
                return Task.FromResult(Notificator.NorOk("Cliente não encontrado", HttpStatusCode.BadRequest));

            return Task.FromResult(Notificator.OK(result));
        }
        public Task<Notificator> GetClientByName(string nome)
        {
            var result = _uow.ClientRepository.GetClientByName(x => x.Nome == nome);
            if (!result.Any() || result.FirstOrDefault() is null)
                return Task.FromResult(Notificator.NorOk("Cliente não encontrado", HttpStatusCode.BadRequest));

            return Task.FromResult(Notificator.OK(result));
        }
    }
}
