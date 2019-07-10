using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Transactions;

namespace WebAPI.Core.DomainModels.Customers
{
    public class CustomerDTO
    {
        public int customerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public List<TransactionDTO> Transactions { get; set; } = new List<TransactionDTO>();
    }
}
