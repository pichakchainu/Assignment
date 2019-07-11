using Assignment.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            mockCustomerRepository.Setup(mr => mr.GetCustomerById(It.IsAny<int>())).Returns((int i) =>
                customers.Where(x => x.Id == i).Select(x => x.toCustomerDTO())
            );

            mockCustomerRepository.Setup(mr => mr.GetCustomerDTOByEmail(It.IsAny<string>())).Returns((string email) =>
               customersAndTransactions.Where(x => x.Email == email).Select(x => x.toCustomerAndOneTransactionDTO())
           );

            mockCustomerRepository.Setup(mr => mr.GetCustomerDTOByIdAndEmail(It.IsAny<int>(), It.IsAny<string>())).Returns((int id, string email) =>
               customersAndTransactions.Where(x => x.Id == id && x.Email == email).Select(x => x.toCustomerDTO())
           );


            this.MockCustomerRepository = mockCustomerRepository.Object;
        }

        [Fact]
        public void GetCustomerDTOById()
        {
            var customers = this.MockCustomerRepository.GetCustomerById(0);
            Assert.True(customers.Any());
        }

        [Fact]
        public void GetCustomerDTOByEmail()
        {
            var customers = this.MockCustomerRepository.GetCustomerDTOByEmail("test1@gmail.com");
            Assert.True(customers.Any());
            Assert.True(customers.FirstOrDefault().Transactions.Count == 1);
        }

        [Fact]
        public void GetCustomerDTOByIdAndEmail()
        {
            var customers = this.MockCustomerRepository.GetCustomerDTOByIdAndEmail(0, "test1@gmail.com");
            Assert.True(customers.Any());
            Assert.True(customers.FirstOrDefault().Transactions.Count == 3);

        }
    }
}
