using Microsoft.EntityFrameworkCore;
using Unity_Of_Work.Models;

namespace Unity_Of_Work.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public ApplicationDbContext(){}
        public DbSet<Client> Clients { get; set; }
    }
}
