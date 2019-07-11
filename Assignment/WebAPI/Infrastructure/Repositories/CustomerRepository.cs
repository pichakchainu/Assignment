using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;
using WebAPI.Core.Helpers.DBContextExtensions;
using WebAPI.Infrastructure.EF;

namespace WebAPI.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AssignmentDbContext assignmentDbContext;
        public CustomerRepository(AssignmentDbContext assignmentDbContext)
        {
            this.assignmentDbContext = assignmentDbContext;
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            return await assignmentDbContext.Customers.GetCustomerDTOByIdAsync(id);
        }

        public async Task<CustomerDTO> GetCustomerDTOByEmailAsync(string email)
        {
            return await assignmentDbContext.Customers.GetCustomerDTOByEmailAsync(email);
        }

        public async Task<CustomerDTO> GetCustomerDTOByIdAndEmailAsync(int id, string email)
        {
            return await assignmentDbContext.Customers.GetCustomerDTOByIdAndEmailAsync(id, email);
        }
    }
}
