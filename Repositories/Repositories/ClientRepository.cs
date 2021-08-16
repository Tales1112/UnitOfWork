using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories.Repositories;

namespace Unity_Of_Work.Repositories.Interfaces
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context) {}
        public IEnumerable<Client> GetClientByName(Expression<Func<Client, bool>> predicate)
        {
            return Get(predicate).OrderBy(x => x.Nome).ToList();
        }
    }
}
