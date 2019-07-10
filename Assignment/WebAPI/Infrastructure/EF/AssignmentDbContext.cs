using Microsoft.EntityFrameworkCore;
using WebAPI.Core.DomainModels.Customers;
using WebAPI.Core.DomainModels.Transactions;
using WebAPI.Infrastructure.EF.Mappings;

namespace WebAPI.Infrastructure.EF
{
    public class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Customer> Customers { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapCustomer();
            modelBuilder.MapTransaction();
            base.OnModelCreating(modelBuilder);
        }
    }
}
