using System;
using Unity_Of_Work.Repositories.Interfaces;

namespace Unity_Of_Work.Repositories.Repositories
{
    public class UnityOfWork : IUnitOfWork, IDisposable
    {
        public ApplicationDbContext _context;
        public IClientRepository ClientRepository { get; set; }
        public IEnderecoRepository EnderecoRepository { get; set; }
        public ITelefoneRepository TelefoneRepository { get; set; }
        public UnityOfWork(ApplicationDbContext context, IClientRepository clientRepository,
             IEnderecoRepository enderecoRepository, ITelefoneRepository telefoneRepository)
        {
            _context = context;
            ClientRepository = clientRepository;
            EnderecoRepository = enderecoRepository;
            TelefoneRepository = telefoneRepository;
        }
        public void Commit() => _context.SaveChanges();
        public void Dispose() => _context.Dispose();
    }
}
