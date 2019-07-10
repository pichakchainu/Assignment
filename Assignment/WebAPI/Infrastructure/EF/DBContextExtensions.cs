using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Infrastructure.EF.Seeding;

namespace WebAPI.Infrastructure.EF
{
    public static class DBContextExtensions
    {
        public static void EnsureSeeded(this AssignmentDbContext context)
        {
            if (!context.Customers.Any())
            {
                MockCustomers.CreateCustomers(context);
            }
        }
    }
}
