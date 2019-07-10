using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebAPI.Core.DomainModels.Base;
using WebAPI.Core.DomainModels.Transactions;

namespace WebAPI.Core.DomainModels.Customers
{
    public class Customer: EntityBase<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public CustomerDTO toCustomerDTO()
        {
            return new CustomerDTO()
            {
                customerID = Id,
                Name = Name,
                Email = Email,
                Mobile = MobileNo,
                Transactions = Transactions.Select(x => x.toTransactionDTO()).ToList()
            };
        }
        public CustomerDTO toCustomerAndOneTransactionDTO()
        {
            return new CustomerDTO()
            {
                customerID = Id,
                Name = Name,
                Email = Email,
                Mobile = MobileNo,
                Transactions = Transactions.Take(1).Select(x => x.toTransactionDTO()).ToList()
            };
        }
    }
}
