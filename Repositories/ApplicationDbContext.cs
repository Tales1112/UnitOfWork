using Microsoft.EntityFrameworkCore;

namespace Unity_Of_Work.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }
    }
}
