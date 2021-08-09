using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Unity_Of_Work.Models;
using Unity_Of_Work.Repositories.Interfaces;

namespace Unity_Of_Work.Repositories.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private ApplicationDbContext _context { get; set; }
        public EnderecoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Endereco> Add(Endereco endereco)
        {
            var result = await _context.Endereco.AddAsync(endereco);
            return result.Entity;
        }
        public void Delete(Endereco entity)
        {
            _context.Endereco.Remove(entity);
        }

        public IEnumerable<Endereco> Get()
        {
            var result = _context.Endereco.ToList();
            return result;
        }

        public IEnumerable<Endereco> Get(Expression<Func<Endereco, bool>> predicate)
        {
            var result = _context.Endereco.Where(predicate).AsEnumerable();
            return result;
        }

        public Endereco GetById(Expression<Func<Endereco, bool>> predicate)
        {
            var result = _context.Endereco.FirstOrDefault(predicate);
            return result;
        }

        public void Update(Endereco entity)
        {
            _context.Endereco.Update(entity);
        }
    }
}
