using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Core.DomainModels.Customers;

namespace WebAPI.Core.Helpers.DBContextExtensions
{
    public static class DBContextCustomerExtensions
    {
        public static IEnumerable<CustomerDTO> GetCustomerDTOById(this DbSet<Customer> dbSet,int id)
        {
            return dbSet.Where(x => x.Id == id).Select(x => x.toCustomerDTO());
        }

        public static IEnumerable<CustomerDTO> GetCustomerDTOByEmail(this DbSet<Customer> dbSet, string email)
        {
            return dbSet.Where(x => x.Email == email).Include(x=>x.Transactions).Select(x => x.toCustomerAndOneTransactionDTO());
        }

        public static IEnumerable<CustomerDTO> GetCustomerDTOByIdAndEmail(this DbSet<Customer> dbSet, int id, string email)
        {
            return dbSet.Where(x =>x.Id==id && x.Email == email).Include(x => x.Transactions).Select(x => x.toCustomerDTO());
        }
    }
}
