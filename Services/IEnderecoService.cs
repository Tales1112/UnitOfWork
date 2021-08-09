using System.Threading.Tasks;
using Unity_Of_Work.Models;

namespace Unity_Of_Work.Services
{
    public interface IEnderecoService
    {
        Task<Notificator> AddEndereco(EnderecoViewModel clientViewModel);
        Task<Notificator> GetAllEnderecos();
        Task<Notificator> GetEnderecoByClient(int clientId);
        Task<Notificator> GetEnderecoById(int id);
        Task<Notificator> RemoveEndereco(EnderecoViewModel clientViewModel);
        Task<Notificator> UpdateEndereco(EnderecoViewModel clientViewModel);
    }
}