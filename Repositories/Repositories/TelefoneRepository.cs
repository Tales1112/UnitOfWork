using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Unity_Of_Work.Models;

namespace Unity_Of_Work.Repositories.Repositories
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        private ApplicationDbContext _context { get; set; }
        public TelefoneRepository(ApplicationDbContext context) : base(context) { }
    }
}
