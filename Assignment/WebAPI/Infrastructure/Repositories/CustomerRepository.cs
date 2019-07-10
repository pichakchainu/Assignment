using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;
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
    }
}
