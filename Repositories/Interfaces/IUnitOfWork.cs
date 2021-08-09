using Unity_Of_Work.Models;

namespace Unity_Of_Work.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Client> ClientRepository { get; }
        IRepository<Endereco> EnderecoRepository { get; }
        IRepository<Telefone> TelefoneRepository { get; }
        void Commit();
    }
}
