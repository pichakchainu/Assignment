using Microsoft.Extensions.Configuration;
using StructureMap;
using WebAPI.Infrastructure.Repositories;

namespace WebAPI.Ioc
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<ICustomerRepository>().Use<CustomerRepository>();
        }
    }
}
