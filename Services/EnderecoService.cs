using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories.Interfaces;
using Unity_Of_Work.Validators;

namespace Unity_Of_Work.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IUnitOfWork _uow;
        public EnderecoService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Task<Notificator> AddEndereco(EnderecoViewModel enderecoViewModel)
        {
            var validator = new EnderecoViewModelValidator().Validate(enderecoViewModel);
            if (!validator.IsValid)
                return Task.FromResult(Notificator.NorOk(validator.Errors[0].ToString(), HttpStatusCode.BadRequest));

            _uow.EnderecoRepository.Add(new Endereco(enderecoViewModel));
            _uow.Commit();

            return Task.FromResult(Notificator.OK("Cliente cadastrado com sucesso"));
        }
        public Task<Notificator> RemoveEndereco(EnderecoViewModel clientViewModel)
        {
            var validator = new EnderecoViewModelValidator().Validate(clientViewModel);
            if (!validator.IsValid)
                return Task.FromResult(Notificator.NorOk(validator.Errors[0].ToString(), HttpStatusCode.BadRequest));

            _uow.EnderecoRepository.Delete(new Endereco(clientViewModel));
            _uow.Commit();
            return Task.FromResult(Notificator.OK("Cliente removido com Sucesso"));
        }
        public Task<Notificator> UpdateEndereco(EnderecoViewModel enderecoViewModel)
        {
            var validator = new EnderecoViewModelValidator().Validate(enderecoViewModel);
            if (!validator.IsValid)
                return Task.FromResult(Notificator.NorOk(validator.Errors[0].ToString(), HttpStatusCode.BadRequest));

            _uow.EnderecoRepository.Update(new Endereco(enderecoViewModel));
            _uow.Commit();
            return Task.FromResult(Notificator.OK("Cliente atualizado com Sucesso"));
        }
        public Task<Notificator> GetAllEnderecos()
        {
            var result = _uow.EnderecoRepository.Get();

            if (!result.Any() || result.FirstOrDefault() is null)
                return Task.FromResult(Notificator.NorOk("Clientes não encontrado nada base", HttpStatusCode.BadRequest));

            return Task.FromResult(Notificator.OK(result));
        }
        public Task<Notificator> GetEnderecoById(int id)
        {
            var result = _uow.EnderecoRepository.GetById(c => c.EnderecoId == id);
            if (result == null)
                return Task.FromResult(Notificator.NorOk("Cliente não encontrado", HttpStatusCode.BadRequest));

            return Task.FromResult(Notificator.OK(result));
        }
        public Task<Notificator> GetEnderecoByClient(int clientId)
        {
            var result = _uow.EnderecoRepository.GetById(c => c.ID_CLIENTE == clientId);

            if (result == null)
                return Task.FromResult(Notificator.NorOk("Cliente não encontrado", HttpStatusCode.BadRequest));

            return Task.FromResult(Notificator.OK(result));
        }
    }
}
