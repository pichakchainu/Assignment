using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;

namespace WebAPI.Services
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task<CustomerDTO> GetCustomerDTOByEmailAsync(string email);
        Task<CustomerDTO> GetCustomerDTOByIdAndEmailAsync(int id, string email);
    }
}
