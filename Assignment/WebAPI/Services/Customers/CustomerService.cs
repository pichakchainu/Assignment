using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;
using WebAPI.Infrastructure.Repositories;

namespace WebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            return await customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<CustomerDTO> GetCustomerDTOByEmailAsync(string email)
        {
            return await customerRepository.GetCustomerDTOByEmailAsync(email);
        }

        public async Task<CustomerDTO> GetCustomerDTOByIdAndEmailAsync(int id, string email)
        {
            return await customerRepository.GetCustomerDTOByIdAndEmailAsync(id, email);
        }
    }
}
