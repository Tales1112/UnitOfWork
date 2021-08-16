using Unity_Of_Work.Repositories.Repositories;

namespace Unity_Of_Work.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
        ITelefoneRepository TelefoneRepository { get; }
        void Commit();
    }
}
