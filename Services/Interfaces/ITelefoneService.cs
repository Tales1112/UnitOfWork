using System.Threading.Tasks;
using Unity_Of_Work.Models;

namespace Unity_Of_Work.Services
{
    public interface ITelefoneService
    {
        Task<Notificator> AdicionarTelefone(TelefoneViewModel telefoneViewModel);
        Task<Notificator> GetAllTelefones();
        Task<Notificator> GetTelefoneByClient(int clientId);
        Task<Notificator> GetTelefoneById(int id);
        Task<Notificator> RemoveTelefone(TelefoneViewModel telefoneViewModel);
        Task<Notificator> UpdateTelefone(TelefoneViewModel telefoneViewModel);
    }
}