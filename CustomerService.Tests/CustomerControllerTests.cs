using System.Threading.Tasks;
using AutoMapper;
using CustomerService.Application.Controllers;
using CustomerService.BusinessLogic.Contexts;
using CustomerService.BusinessLogic.Models;
using CustomerService.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatsExtensions.Proxies;
using NSubstitute;
using NUnit.Framework;

namespace CustomerService.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private ICustomerService _customerService;
        private CustomerController _customerController;
        private IProxy<GetOrdersByCustomerIdRequest, GetOrdersByCustomerIdReply> _orderServiceProxy;
        private CustomerContext _dbContext;
        private IMapper _mapper;
        
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
                .UseInMemoryDatabase(databaseName: "testCustomersDb")
                .Options;
            _dbContext = new CustomerContext(options);
            _mapper = new Mapper(new MapperConfiguration(configure => configure.AddMaps("CustomerService.BusinessLogic")));
            _customerService = new BusinessLogic.Services.CustomerService(_dbContext);
            _orderServiceProxy = Substitute.For<IProxy<GetOrdersByCustomerIdRequest, GetOrdersByCustomerIdReply>>();
            _customerController = new CustomerController(_orderServiceProxy, _customerService, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext = null;
            _customerService = null;
            _customerController = null;
        }

        [TestCaseSource(
            typeof(CustomerControllerTestCaseSources),
            nameof(CustomerControllerTestCaseSources.GetAddCustomerInvalidParameters))]
        public async Task TestAddCustomerWithInvalidParameters(AddCustomerRequest request, AddCustomerReply reply)
        {
            // Arrange.
            _customerController.ModelState.AddModelError("error", "invalid request");

            // Act.
            var result = await _customerController.AddCustomer(request);

            // Assert.
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ActionResult<AddCustomerReply>>());
            Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
        }
        
        [TestCaseSource(
            typeof(CustomerControllerTestCaseSources),
            nameof(CustomerControllerTestCaseSources.GetAddCustomerValidParameters))]
        public async Task TestAddCustomerWithValidParameters(AddCustomerRequest request, AddCustomerReply expectedReply)
        {
            // Arrange.

            // Act.
            var reply = await _customerController.AddCustomer(request);

            // Assert.
            Assert.That(reply, Is.Not.Null);
            
            Assert.That(reply, Is.InstanceOf<ActionResult<AddCustomerReply>>());

            var okObjectResult = reply.Result as OkObjectResult;
            Assert.That(okObjectResult, Is.Not.Null);

            var replyValue = okObjectResult.Value as AddCustomerReply;
            Assert.That(replyValue, Is.Not.Null);
            
            Assert.That(replyValue.FirstName, Is.EqualTo(expectedReply.FirstName));
            Assert.That(replyValue.LastName, Is.EqualTo(expectedReply.LastName));
            Assert.That(replyValue.MiddleName, Is.EqualTo(expectedReply.MiddleName));
        }
    }
}