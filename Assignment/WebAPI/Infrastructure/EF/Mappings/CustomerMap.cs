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
            entity.Property(c => c.Id).HasMaxLength(10);
            entity.Property(c => c.Name).HasMaxLength(30);
            entity.Property(c => c.Email).HasMaxLength(25);
            entity.Property(c => c.MobileNo).HasMaxLength(10);
            entity.HasMany(c => c.Transactions).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
            return modelBuilder;
        }
    }
}
