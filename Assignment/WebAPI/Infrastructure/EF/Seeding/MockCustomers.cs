using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;
using WebAPI.Core.DomainModels.Transactions;

namespace WebAPI.Infrastructure.EF.Seeding
{
    public static class MockCustomers
    {
        public static void CreateCustomers(AssignmentDbContext assignmentDbContext)
        {
            for (int i = 1; i <= 5; i++)
            {
                var item = new Customer()
                {
                    Name = $"test{i}",
                    Email = $"test{i}@gmail.com",
                    MobileNo = $"063544555{i}"
                };
                assignmentDbContext.Customers.Add(item);
            }
            assignmentDbContext.SaveChanges();
          
        }

    }
}
