using Microsoft.Extensions.Configuration;
using StructureMap;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Services;
using WebAPI.Services.Customers;

namespace WebAPI.Ioc
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<ICustomerRepository>().Use<CustomerRepository>();
            For<ICustomerService>().Use<CustomerService>();
            For<ICustomerValidationService>().Use<CustomerValidationService>();
        }
    }
}
