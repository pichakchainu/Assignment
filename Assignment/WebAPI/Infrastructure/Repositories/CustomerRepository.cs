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
        public IEnumerable<Customer> GetAll()
        {
            return assignmentDbContext.Customers;
        }
        public bool Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDTO> GetCustomerById(int id)
        {
            return assignmentDbContext.Customers.GetCustomerDTOById(id);
        }

        public IEnumerable<CustomerDTO> GetCustomerDTOByEmail(string email)
        {
            return assignmentDbContext.Customers.GetCustomerDTOByEmail(email);
        }

        public IEnumerable<CustomerDTO> GetCustomerDTOByIdAndEmail(int id, string email)
        {
            return assignmentDbContext.Customers.GetCustomerDTOByIdAndEmail(id, email);
        }
    }
}
