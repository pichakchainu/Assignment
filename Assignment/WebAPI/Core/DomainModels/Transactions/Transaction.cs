using System;
using WebAPI.Core.DomainModels.Customers;

namespace WebAPI.Core.DomainModels.Transactions
{
    public class Transaction
    {
        public Transaction()
        {
        }
     
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode  { get; set; }
        public TransactionStatus Status { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
    public enum TransactionStatus
    {
        Success,
        Failed,
        Canceled
    }
}
