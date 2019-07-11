using Assignment.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Core.DomainModels.Customers;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Services;
using Xunit;

namespace Assignment.Test.IntegrationTests.Repositories
{
    public class CustomerRepositoryTests
    {
        public readonly ICustomerRepository MockCustomerRepository;
        public CustomerRepositoryTests()
        {
            var customer = new CustomerDTO();
            
            var customersAndTransactions = MockCustomers.CreateCustomersAndTransactions();
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();

            mockCustomerRepository.Setup(mr => mr.GetCustomerByIdAsync(It.IsAny<int>())).ReturnsAsync(customer);

            mockCustomerRepository.Setup(mr => mr.GetCustomerDTOByEmailAsync(It.IsAny<string>())).ReturnsAsync((string email) =>
               customersAndTransactions.Where(x => x.Email == email).Select(x => x.toCustomerAndOneTransactionDTO()).SingleOrDefault()
           );

            mockCustomerRepository.Setup(mr => mr.GetCustomerDTOByIdAndEmailAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((int id, string email) =>
               customersAndTransactions.Where(x => x.Id == id && x.Email == email).Select(x => x.toCustomerDTO()).SingleOrDefault()
           );


            this.MockCustomerRepository = mockCustomerRepository.Object;
        }

        [Fact]
        public async Task GetCustomerDTOById()
        {
            var customer = await MockCustomerRepository.GetCustomerByIdAsync(1);
            Assert.NotNull(customer);
        }

        [Fact]
        public async Task GetCustomerDTOByEmail()
        {
            var customer = await MockCustomerRepository.GetCustomerDTOByEmailAsync("test1@gmail.com");
            Assert.NotNull(customer);
            Assert.True(customer.Transactions.Count == 1);
        }

        [Fact]
        public async Task GetCustomerDTOByIdAndEmail()
        {
            var customer = await MockCustomerRepository.GetCustomerDTOByIdAndEmailAsync(0, "test1@gmail.com");
            Assert.NotNull(customer);
            Assert.True(customer.Transactions.Count == 3);

        }
    }
}
