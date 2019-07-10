using Microsoft.EntityFrameworkCore;
using WebAPI.Core.DomainModels.Transactions;

namespace WebAPI.Infrastructure.EF.Mappings
{
    public static class TransactionMap
    {
        public static ModelBuilder MapTransaction(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Transaction>();
            entity.ToTable("Transactions");
            entity.Property(c => c.Id);
            entity.Property(c => c.Date);
            entity.Property(c => c.Amount);
            entity.Property(c => c.CurrencyCode);
            entity.Property(c => c.Status);
            return modelBuilder;
        }
    }
}
