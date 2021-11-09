using CustomerService.Contract.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.BusinessLogic.Contexts
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerContext(DbContextOptions options) : base(options)
        {
        }
    }
}

