using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerService.Contract.Entities;
using CustomerService.Contract.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace CustomerService.Tests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private ICustomerService _customerService;

        [SetUp]
        public void SetUp()
        {
            // Проводим инициализацию перед началом тестирования
            _customerService = Substitute.For<ICustomerService>();
        }

        [TearDown]
        public void TearDown()
        {
            // Проводим очистку данных после тестирования
            _customerService = null;
        }

        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetAddCustomerInvalidParameters))]
        public async Task TestAddCustomerWithInvalidArguments(Customer customer)
        {
            // Arrange.
            _customerService.AddCustomerAsync(default).ReturnsForAnyArgs(Task.FromException<Customer>(new ArgumentException()));

            // Act.

            // Assert.
            Assert.ThrowsAsync<ArgumentException>(async () => await _customerService.AddCustomerAsync(customer));
        }

        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetAddCustomerValidParameters))]
        public async Task TestAddCustomerWithValidArguments(Customer customer)
        {
            // Arrange.
            _customerService.AddCustomerAsync(customer).Returns(new Customer
            {
                Id = 1, 
                FirstName = customer.FirstName, 
                LastName = customer.LastName, 
                MiddleName = customer.MiddleName
            });

            // Act.
            var result = await _customerService.AddCustomerAsync(customer);

            // Assert.
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo(customer.FirstName));
            Assert.That(result.LastName, Is.EqualTo(customer.LastName));
            Assert.That(result.MiddleName, Is.EqualTo(customer.MiddleName));
        }

        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetUpdateCustomerInvalidParameters))]
        public async Task TestUpdateCustomerWithInvalidArguments(long customerId, Customer customer)
        {
            // Arrange.
            _customerService.UpdateCustomerAsync(default).ReturnsForAnyArgs(Task.FromException<Customer>(new ArgumentException()));

            // Act.

            // Assert.
            Assert.ThrowsAsync<ArgumentException>(async () => await _customerService.UpdateCustomerAsync(customer));
        }

        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetUpdateCustomerValidParameters))]
        public async Task TestUpdateCustomerWithValidArguments(long customerId, Customer customer)
        {
            // Arrange.
            _customerService.UpdateCustomerAsync(customer).Returns(new Customer
            {
                Id = 1, 
                FirstName = customer.FirstName, 
                LastName = customer.LastName, 
                MiddleName = customer.MiddleName
            });

            // Act.
            var result = await _customerService.UpdateCustomerAsync(customer);

            // Assert.
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo(customer.FirstName));
            Assert.That(result.LastName, Is.EqualTo(customer.LastName));
            Assert.That(result.MiddleName, Is.EqualTo(customer.MiddleName));
        }
        
        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetDeleteCustomerInvalidParameters))]
        public void TestDeleteCustomerWithInvalidArguments(long customerId)
        {
            // Arrange.
            _customerService.DeleteCustomerAsync(default).ReturnsForAnyArgs(Task.FromException<Customer>(new ArgumentException()));
        
            // Act.
        
            // Assert.
            Assert.ThrowsAsync<ArgumentException>(async () => await _customerService.DeleteCustomerAsync(customerId));
        }
        
        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetDeleteCustomerValidParameters))]
        public async Task TestDeleteCustomerWithValidArguments(long customerId, Customer expected)
        {
            // Arrange.
            _customerService.DeleteCustomerAsync(customerId).Returns(expected);
        
            // Act.
            var result = await _customerService.DeleteCustomerAsync(customerId);
        
            // Assert.
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo(expected.FirstName));
            Assert.That(result.LastName, Is.EqualTo(expected.LastName));
            Assert.That(result.MiddleName, Is.EqualTo(expected.MiddleName));
        }
        
        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetCustomerByIdInvalidParameters))]
        public void TestGetCustomerByIdWithInvalidArguments(long customerId)
        {
            // Arrange.
            _customerService.GetCustomerByIdAsync(default).ReturnsForAnyArgs(Task.FromException<Customer>(new ArgumentException()));
        
            // Act.
        
            // Assert.
            Assert.ThrowsAsync<ArgumentException>(async () => await _customerService.GetCustomerByIdAsync(customerId));
        }
        
        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetCustomerByIdValidParameters))]
        public async Task TestGetCustomerByIdWithValidArguments(long customerId, Customer expected)
        {
            // Arrange.
            _customerService.GetCustomerByIdAsync(customerId).Returns(expected);
        
            // Act.
            var result = await _customerService.GetCustomerByIdAsync(customerId);
        
            // Assert.
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo(expected.FirstName));
            Assert.That(result.LastName, Is.EqualTo(expected.LastName));
            Assert.That(result.MiddleName, Is.EqualTo(expected.MiddleName));
        }

        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetAllCustomersParameters))]
        public async Task TestGetAllCustomers(List<Customer> expected)
        {
            // Arrange.
            _customerService.GetAllCustomersAsync().Returns(expected);
        
            // Act.
            var result = await _customerService.GetAllCustomersAsync();
        
            // Assert.
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            for (int i = 0; i < result.Count; i++)
            {
                Assert.That(result[i].Id, Is.EqualTo(expected[i].Id));
                Assert.That(result[i].FirstName, Is.EqualTo(expected[i].FirstName));
                Assert.That(result[i].LastName, Is.EqualTo(expected[i].LastName));
                Assert.That(result[i].MiddleName, Is.EqualTo(expected[i].MiddleName));
            }
        }
    }
}