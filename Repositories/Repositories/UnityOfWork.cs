using System;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories.Interfaces;

namespace Unity_Of_Work.Repositories.Repositories
{
    public class UnityOfWork : IUnitOfWork, IDisposable
    {
        public ApplicationDbContext _context;
        private IRepository<Client> _clientRepository;
        private IRepository<Endereco> _enderecoRepository;
        private IRepository<Telefone> _telefoneRepository;
        public UnityOfWork(ApplicationDbContext context, IRepository<Client> clientRepository, IRepository<Endereco> enderecoRepository, IRepository<Telefone> telefoneRepository)
        {
            _context = context;
            _clientRepository = clientRepository;
            _enderecoRepository = enderecoRepository;
            _telefoneRepository = telefoneRepository;
        }
        public UnityOfWork(ApplicationDbContext context, IClientRepository clientRepository, IEnderecoRepository enderecoRepository)
        {
            _context = context;
            _clientRepository = clientRepository;
            _enderecoRepository = enderecoRepository;
        }
        public IRepository<Client> ClientRepository
        {
            get
            {
                return _clientRepository = _clientRepository ?? new Repository<Client>(_context);
            }
        }
        public IRepository<Endereco> EnderecoRepository
        {
            get
            {
                return _enderecoRepository = _enderecoRepository ?? new Repository<Endereco>(_context);
            }
        }
        public IRepository<Telefone> TelefoneRepository
        {
            get
            {
                return _telefoneRepository = _telefoneRepository ?? new Repository<Telefone>(_context);
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
