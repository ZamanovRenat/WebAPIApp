using Microsoft.EntityFrameworkCore;
using WebAPIApp.Core.Domain.Administration;

namespace WebAPIApp.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DataContext(DbContextOptions<DataContext> dbContextOptions) 
            : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
