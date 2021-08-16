using System.Net;
using System.Threading.Tasks;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories.Interfaces;
using Unity_Of_Work.Validators;

namespace Unity_Of_Work.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly IUnitOfWork _uow;
        public TelefoneService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task<Notificator> AdicionarTelefone(TelefoneViewModel telefoneViewModel)
        {
            var result = new TelefoneViewModelValidator().Validate(telefoneViewModel);

            if (!result.IsValid)
                return Task.FromResult(Notificator.NorOk(result.Errors[0].ToString(), HttpStatusCode.BadRequest));

            _uow.TelefoneRepository.Add(new Telefone(telefoneViewModel));
            _uow.Commit();

            return Task.FromResult(Notificator.OK("Telefone cadastrado com sucesso"));
        }
        public Task<Notificator> RemoveTelefone(TelefoneViewModel telefoneViewModel)
        {
            var validator = new TelefoneViewModelValidator().Validate(telefoneViewModel);
            if (!validator.IsValid)
                return Task.FromResult(Notificator.NorOk(validator.Errors[0].ToString(), HttpStatusCode.BadRequest));

            _uow.TelefoneRepository.Delete(new Telefone(telefoneViewModel));
            _uow.Commit();
            return Task.FromResult(Notificator.OK("Cliente removido com Sucesso"));
        }
        public Task<Notificator> UpdateTelefone(TelefoneViewModel telefoneViewModel)
        {
            var validator = new TelefoneViewModelValidator().Validate(telefoneViewModel);
            if (!validator.IsValid)
                return Task.FromResult(Notificator.NorOk(validator.Errors[0].ToString(), HttpStatusCode.BadRequest));

            _uow.TelefoneRepository.Update(new Telefone(telefoneViewModel));
            _uow.Commit();
            return Task.FromResult(Notificator.OK("Cliente atualizado com Sucesso"));
        }
        public Task<Notificator> GetAllTelefones()
        {
            var result = _uow.EnderecoRepository.Get();

            if (result == null)
                return Task.FromResult(Notificator.NorOk("Clientes não encontrado nada base", HttpStatusCode.BadRequest));

            return Task.FromResult(Notificator.OK(result));
        }
        public Task<Notificator> GetTelefoneById(int id)
        {
            var result = _uow.EnderecoRepository.GetById(c => c.EnderecoId == id);
            if (result == null)
                return Task.FromResult(Notificator.NorOk("Cliente não encontrado", HttpStatusCode.BadRequest));

            return Task.FromResult(Notificator.OK(result));
        }
        public Task<Notificator> GetTelefoneByClient(int clientId)
        {
            var result = _uow.EnderecoRepository.GetById(c => c.ID_CLIENTE == clientId);

            if (result == null)
                return Task.FromResult(Notificator.NorOk("Cliente não encontrado", HttpStatusCode.BadRequest));

            return Task.FromResult(Notificator.OK(result));
        }
    }
}
