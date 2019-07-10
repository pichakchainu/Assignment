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
        public IEnumerable<CustomerDTO> GetCustomerById(int id)
        {
            return customerRepository.GetCustomerById(id);
        }

        public IEnumerable<CustomerDTO> GetCustomerDTOByEmail(string email)
        {
            return customerRepository.GetCustomerDTOByEmail(email);
        }

        public IEnumerable<CustomerDTO> GetCustomerDTOByIdAndEmail(int id, string email)
        {
            return customerRepository.GetCustomerDTOByIdAndEmail(id, email);
        }
    }
}
