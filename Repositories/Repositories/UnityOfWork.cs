using System;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories.Interfaces;

namespace Unity_Of_Work.Repositories.Repositories
{
    public class UnityOfWork : IUnitOfWork, IDisposable
    {
        public ApplicationDbContext _context;
        private IRepository<Client> _clientRepository;
        public UnityOfWork(ApplicationDbContext context, IRepository<Client> clientRepository)
        {
            _context = context;
            _clientRepository = clientRepository;
        }
        public UnityOfWork(ApplicationDbContext context, IClientRepository clientRepository)
        {
            _context = context;
            _clientRepository = clientRepository;
        }
        public IRepository<Client> ClientRepository
        {
            get
            {
                return _clientRepository = _clientRepository ?? new Repository<Client>(_context);
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
