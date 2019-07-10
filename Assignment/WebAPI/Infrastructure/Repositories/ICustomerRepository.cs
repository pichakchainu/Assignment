﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;

namespace WebAPI.Infrastructure.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        IEnumerable<CustomerDTO> GetCustomerById(int id);
        IEnumerable<CustomerDTO> GetCustomerDTOByEmail(string email);
        IEnumerable<CustomerDTO> GetCustomerDTOByIdAndEmail(int id,string email);

    }
}
