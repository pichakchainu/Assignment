using Microsoft.EntityFrameworkCore;
using WebAPI.Core.DomainModels.Customers;

namespace WebAPI.Infrastructure.EF.Mappings
{
    public static class CustomerMap
    {
        public static ModelBuilder MapCustomer(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Customer>();
            entity.ToTable("Customers");
            entity.Property(c => c.Id);
            entity.Property(c => c.Name);
            entity.Property(c => c.Email);
            entity.Property(c => c.MobileNo);
            entity.HasMany(c => c.Transactions).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
            return modelBuilder;
        }
    }
}
