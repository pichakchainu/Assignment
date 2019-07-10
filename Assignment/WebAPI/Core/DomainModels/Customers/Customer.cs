using System.Collections.Generic;
using WebAPI.Core.DomainModels.Transactions;

namespace WebAPI.Core.DomainModels.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
