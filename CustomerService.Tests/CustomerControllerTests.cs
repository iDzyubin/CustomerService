using AutoMapper;
using CustomerService.Application.Controllers;
using CustomerService.BusinessLogic.Contexts;
using CustomerService.BusinessLogic.Models;
using CustomerService.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CustomerService.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private ICustomerService _customerService;
        private CustomerController _customerController;
        private ApplicationDbContext _dbContext;
        private IMapper _mapper;
        
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "testCustomersDb")
                .Options;
            _dbContext = new ApplicationDbContext(options);
            _mapper = new Mapper(new MapperConfiguration(configure => configure.AddMaps("CustomerService.BusinessLogic")));
            _customerService = new BusinessLogic.Services.CustomerService(_dbContext);
            _customerController = new CustomerController(_customerService, _mapper);
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
        public void TestAddCustomerWithInvalidParameters(AddCustomerRequest request, AddCustomerReply reply)
        {
            // Arrange.
            _customerController.ModelState.AddModelError("error", "invalid request");

            // Act.
            var result = _customerController.AddCustomer(request);

            // Assert.
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ActionResult<AddCustomerReply>>());
            Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
        }
        
        [TestCaseSource(
            typeof(CustomerControllerTestCaseSources),
            nameof(CustomerControllerTestCaseSources.GetAddCustomerValidParameters))]
        public void TestAddCustomerWithValidParameters(AddCustomerRequest request, AddCustomerReply expectedReply)
        {
            // Arrange.

            // Act.
            var reply = _customerController.AddCustomer(request);

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