using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;

namespace WebAPI.Core.Helpers.DBContextExtensions
{
    public static class DBContextCustomerExtensions
    {
        public static async Task<IEnumerable<CustomerDTO>> GetCustomerDTOByIdAsync(this DbSet<Customer> dbSet,int id)
        {
            return await dbSet.Where(x => x.Id == id).Select(x => x.toCustomerDTO()).ToArrayAsync();
        }

        public static async Task<IEnumerable<CustomerDTO>> GetCustomerDTOByEmailAsync(this DbSet<Customer> dbSet, string email)
        {
            return await dbSet.Where(x => x.Email == email).Include(x=>x.Transactions).Select(x => x.toCustomerAndOneTransactionDTO()).ToArrayAsync();
        }

        public static async Task<IEnumerable<CustomerDTO>> GetCustomerDTOByIdAndEmailAsync(this DbSet<Customer> dbSet, int id, string email)
        {
            return await dbSet.Where(x =>x.Id==id && x.Email == email).Include(x => x.Transactions).Select(x => x.toCustomerDTO()).ToArrayAsync();
        }
    }
}
