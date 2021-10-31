using System;
using System.Collections.Generic;
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
        public void TestAddCustomerWithInvalidArguments(Customer customer)
        {
            // Arrange.
            _customerService.AddCustomer(default).ReturnsForAnyArgs(x => throw new ArgumentException());

            // Act.

            // Assert.
            Assert.Throws<ArgumentException>(() => _customerService.AddCustomer(customer));
        }

        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetAddCustomerValidParameters))]
        public void TestAddCustomerWithValidArguments(Customer customer)
        {
            // Arrange.
            _customerService.AddCustomer(customer).Returns(new Customer
            {
                Id = 1, 
                FirstName = customer.FirstName, 
                LastName = customer.LastName, 
                MiddleName = customer.MiddleName
            });

            // Act.
            var result = _customerService.AddCustomer(customer);

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
        public void TestUpdateCustomerWithInvalidArguments(long customerId, Customer customer)
        {
            // Arrange.
            _customerService.UpdateCustomer(default, default).ReturnsForAnyArgs(x => throw new ArgumentException());

            // Act.

            // Assert.
            Assert.Throws<ArgumentException>(() => _customerService.UpdateCustomer(customerId, customer));
        }

        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetUpdateCustomerValidParameters))]
        public void TestUpdateCustomerWithValidArguments(long customerId, Customer customer)
        {
            // Arrange.
            _customerService.UpdateCustomer(customerId, customer).Returns(new Customer
            {
                Id = 1, 
                FirstName = customer.FirstName, 
                LastName = customer.LastName, 
                MiddleName = customer.MiddleName
            });

            // Act.
            var result = _customerService.UpdateCustomer(customerId, customer);

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
            _customerService.DeleteCustomer(default).ReturnsForAnyArgs(x => throw new ArgumentException());
        
            // Act.
        
            // Assert.
            Assert.Throws<ArgumentException>(() => _customerService.DeleteCustomer(customerId));
        }
        
        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetDeleteCustomerValidParameters))]
        public void TestDeleteCustomerWithValidArguments(long customerId, Customer expected)
        {
            // Arrange.
            _customerService.DeleteCustomer(customerId).Returns(expected);
        
            // Act.
            var result = _customerService.DeleteCustomer(customerId);
        
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
            _customerService.GetCustomerById(default).ReturnsForAnyArgs(x => throw new ArgumentException());
        
            // Act.
        
            // Assert.
            Assert.Throws<ArgumentException>(() => _customerService.GetCustomerById(customerId));
        }
        
        [TestCaseSource(
            typeof(CustomerServiceTestCaseSources),
            nameof(CustomerServiceTestCaseSources.GetCustomerByIdValidParameters))]
        public void TestGetCustomerByIdWithValidArguments(long customerId, Customer expected)
        {
            // Arrange.
            _customerService.GetCustomerById(customerId).Returns(expected);
        
            // Act.
            var result = _customerService.GetCustomerById(customerId);
        
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
        public void TestGetAllCustomers(List<Customer> expected)
        {
            // Arrange.
            _customerService.GetAllCustomers().Returns(expected);
        
            // Act.
            var result = _customerService.GetAllCustomers();
        
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