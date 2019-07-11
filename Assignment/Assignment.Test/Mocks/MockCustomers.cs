using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Core.DomainModels.Customers;
using WebAPI.Core.DomainModels.Transactions;

namespace Assignment.Test.Mocks
{
    public static class MockCustomers
    {
        public static List<Customer> CreateCustomers()
        {
            List<Customer> items = new List<Customer>();
            for (int i = 1; i <= 5; i++)
            {
                var item = new Customer()
                {
                    Name = $"test{i}",
                    Email = $"test{i}@gmail.com",
                    MobileNo = $"063544555{i}"
                };
                items.Add(item);
            }
            return items;
        }

        public static List<Customer> CreateCustomersAndTransactions()
        {
            Random random = new Random();
            List<Customer> items = new List<Customer>();
            for (int i = 1; i <= 5; i++)
            {
                var item = new Customer()
                {
                    Name = $"test{i}",
                    Email = $"test{i}@gmail.com",
                    MobileNo = $"063544555{i}"
                };
                var item1 = new Transaction()
                {
                    CustomerId = item.Id,
                    Customer = item,
                    Date = DateTime.Now.AddDays(-1),
                    Amount = (decimal)1234.56 + (1 * random.Next(10, 50)),
                    CurrencyCode = "USD",
                    Status = TransactionStatus.Success
                };
                item.Transactions.Add(item1);
                var item2 = new Transaction()
                {
                    CustomerId = item.Id,
                    Customer = item,
                    Date = DateTime.Now.AddDays(-2).AddHours(-5),
                    Amount = (decimal)14.16 + (2 * random.Next(10, 50)),
                    CurrencyCode = "THB",
                    Status = TransactionStatus.Failed
                };
                item.Transactions.Add(item2);
                var item3 = new Transaction()
                {
                    CustomerId = item.Id,
                    Customer = item,
                    Date = DateTime.Now.AddDays(-3).AddHours(-3),
                    Amount = (decimal)109.07 + (3 * random.Next(10, 50)),
                    CurrencyCode = "JPY",
                    Status = TransactionStatus.Canceled
                };
                item.Transactions.Add(item3);
                items.Add(item);
            }
            return items;
        }
    }
}
