using Unity_Of_Work.Models;

namespace Unity_Of_Work.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Client> ClientRepository { get; }
        void Commit();
    }
}
