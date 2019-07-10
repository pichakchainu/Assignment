using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;

namespace WebAPI.Infrastructure.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
    }
}
