using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Core.DomainModels.Base;
using WebAPI.Core.DomainModels.Customers;

namespace WebAPI.Core.DomainModels.Transactions
{
    public class Transaction : EntityBase<int>
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode  { get; set; }
        public TransactionStatus Status { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public TransactionDTO toTransactionDTO()
        {
            return new TransactionDTO
            {
                Id = Id,
                Date = Date.ToString("dd/MM/yyyy hh:mm"),
                Amount = Amount,
                CurrencyCode = CurrencyCode,
                Status = Status.ToString()
            };
        }
    }
    public enum TransactionStatus
    {
        Success,
        Failed,
        Canceled
    }
}
