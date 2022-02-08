using Microsoft.EntityFrameworkCore;
using WebAPIApp.Core.Domain.Administration;
using WebAPIApp.Core.Domain.PromoCodeManagement;

namespace WebAPIApp.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DataContext(DbContextOptions<DataContext> dbContextOptions) 
            : base(dbContextOptions)
        {
           // Database.EnsureCreated();
        }
        //Конфигурирование моделей
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
