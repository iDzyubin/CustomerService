using CustomerService.Contract.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.BusinessLogic.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            // Create db after start application
            Database.EnsureCreated();
        }
    }
}

