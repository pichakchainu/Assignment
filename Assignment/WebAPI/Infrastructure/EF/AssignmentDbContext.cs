using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebAPI.Core.DomainModels.Base;
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapCustomer();
            modelBuilder.MapTransaction();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            AddEntityData();
            return base.SaveChanges();
        }

        private void AddEntityData()
        {
            if (this.ChangeTracker != null && this.ChangeTracker.Entries() != null)
            {
                var entities = this.ChangeTracker.Entries().Where(x => x.Entity is EntityBase<Guid> && (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();

                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((EntityBase<Guid>)entity.Entity).CreatedDate = DateTime.UtcNow;
                        ((EntityBase<Guid>)entity.Entity).UpdatedDate = DateTime.UtcNow;
                    }
                    else
                        ((EntityBase<Guid>)entity.Entity).UpdatedDate = DateTime.UtcNow;
                }
            }
        }
    }
}
