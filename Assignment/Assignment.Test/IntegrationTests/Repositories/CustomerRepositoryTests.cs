using Assignment.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var customers = MockCustomers.CreateCustomers();
            var customersAndTransactions = MockCustomers.CreateCustomersAndTransactions();
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();

            mockCustomerRepository.Setup(mr => mr.GetCustomerByIdAsync(It.IsAny<int>())).ReturnsAsync((int i) =>
                customers.Where(x => x.Id == i).Select(x => x.toCustomerDTO())
            );

            mockCustomerRepository.Setup(mr => mr.GetCustomerDTOByEmailAsync(It.IsAny<string>())).ReturnsAsync((string email) =>
               customersAndTransactions.Where(x => x.Email == email).Select(x => x.toCustomerAndOneTransactionDTO())
           );

            mockCustomerRepository.Setup(mr => mr.GetCustomerDTOByIdAndEmailAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync((int id, string email) =>
               customersAndTransactions.Where(x => x.Id == id && x.Email == email).Select(x => x.toCustomerDTO())
           );


            this.MockCustomerRepository = mockCustomerRepository.Object;
        }

        [Fact]
        public async Task GetCustomerDTOById()
        {
            var customers = await MockCustomerRepository.GetCustomerByIdAsync(0);
            Assert.True(customers.Any());
        }

        [Fact]
        public async Task GetCustomerDTOByEmail()
        {
            var customers = await MockCustomerRepository.GetCustomerDTOByEmailAsync("test1@gmail.com");
            Assert.True(customers.Any());
            Assert.True(customers.FirstOrDefault().Transactions.Count == 1);
        }

        [Fact]
        public async Task GetCustomerDTOByIdAndEmail()
        {
            var customers = await MockCustomerRepository.GetCustomerDTOByIdAndEmailAsync(0, "test1@gmail.com");
            Assert.True(customers.Any());
            Assert.True(customers.FirstOrDefault().Transactions.Count == 3);

        }
    }
}
