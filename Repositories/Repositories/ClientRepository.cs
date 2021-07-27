using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Unity_Of_Work.Models;

namespace Unity_Of_Work.Repositories.Interfaces
{
    public class ClientRepository :  IClientRepository
    {
        private ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Client> Add(Client entity)
        {
           var result = await _context.Clients.AddAsync(entity);
            return result.Entity;
        }

        public void Delete(Client entity)
        {
            var result =  _context.Clients.Remove(entity);
        }

        public IEnumerable<Client> Get()
        {
            return _context.Clients.ToList();
        }

        public IEnumerable<Client> Get(Expression<Func<Client, bool>> predicate)
        {
            return _context.Clients.Where(predicate).AsEnumerable();
        }

        public Client GetById(Expression<Func<Client, bool>> predicate)
        {
            return _context.Clients.FirstOrDefault(predicate);
        }

        public void Update(Client entity)
        {
            _context.Clients.Update(entity);
        }

        public IEnumerable<Client> GetClientByName(Expression<Func<Client, bool>> predicate)
        {
            return Get().OrderBy(c => c.Nome).ToList();
        }
    }
}
