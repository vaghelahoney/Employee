using Employee.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employees> Employees { get; set; }

    }
}
