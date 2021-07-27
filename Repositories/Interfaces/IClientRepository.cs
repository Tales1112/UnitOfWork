using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity_Of_Work.Models;

namespace Unity_Of_Work.Repositories.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        IEnumerable<Client> GetClientByName(Expression<Func<Client, bool>> predicate);
    }
}