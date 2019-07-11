using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;

namespace WebAPI.Infrastructure.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<CustomerDTO>> GetCustomerByIdAsync(int id);
        Task<IEnumerable<CustomerDTO>> GetCustomerDTOByEmailAsync(string email);
        Task<IEnumerable<CustomerDTO>> GetCustomerDTOByIdAndEmailAsync(int id, string email);

    }
}
