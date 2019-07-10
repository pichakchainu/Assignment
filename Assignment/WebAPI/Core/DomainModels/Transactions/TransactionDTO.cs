using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.DomainModels.Transactions
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }

    }
}
