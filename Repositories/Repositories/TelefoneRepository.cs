using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Unity_Of_Work.Models;

namespace Unity_Of_Work.Repositories.Repositories
{
    public class TelefoneRepository
    {
        private ApplicationDbContext _context { get; set; }

        public TelefoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Telefone> AdicinonarTelefone(Telefone telefone)
        {
            var result = await _context.Telefones.AddAsync(telefone);
            return result.Entity;
        }

        public void Delete(Endereco entity)
        {
            _context.Endereco.Remove(entity);
        }

        public IEnumerable<Telefone> Get()
        {
            var result = _context.Telefones.ToList();
            return result;
        }

        public IEnumerable<Telefone> Get(Expression<Func<Telefone, bool>> predicate)
        {
            var result = _context.Telefones.Where(predicate).AsEnumerable();
            return result;
        }

        public Telefone GetById(Expression<Func<Telefone, bool>> predicate)
        {
            var result = _context.Telefones.FirstOrDefault(predicate);
            return result;
        }

        public void Update(Telefone entity)
        {
            _context.Telefones.Update(entity);
        }
    }
}
