using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Transactions;

namespace WebAPI.Infrastructure.EF.Seeding
{
    public class MockTransactions
    {
        public static void CreateTransactions(AssignmentDbContext assignmentDbContext)
        {
            Random random = new Random();
            var customer = assignmentDbContext.Customers.FirstOrDefault();

            var item1 = new Transaction()
            {
                CustomerId = customer.Id,
                Customer= customer,
                Date = DateTime.Now.AddDays(-1),
                Amount = (decimal)1234.56 + (1 * random.Next(10, 50)),
                CurrencyCode = "USD",
                Status = TransactionStatus.Success
            };
            assignmentDbContext.Transactions.Add(item1);
            var item2 = new Transaction()
            {
                CustomerId = customer.Id,
                Customer = customer,
                Date = DateTime.Now.AddDays(-2).AddHours(-5),
                Amount = (decimal)14.16 + (2 * random.Next(10, 50)),
                CurrencyCode = "THB",
                Status = TransactionStatus.Failed
            };
            assignmentDbContext.Transactions.Add(item2);
            var item3 = new Transaction()
            {
                CustomerId = customer.Id,
                Customer = customer,
                Date = DateTime.Now.AddDays(-3).AddHours(-3),
                Amount = (decimal)109.07 + (3 * random.Next(10, 50)),
                CurrencyCode = "JPY",
                Status = TransactionStatus.Canceled
            };
            assignmentDbContext.Transactions.Add(item3);
            assignmentDbContext.SaveChanges();


        }
    }
}
