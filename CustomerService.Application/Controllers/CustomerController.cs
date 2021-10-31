using CustomerService.Contract.Entities;
using CustomerService.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Application.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpGet("{customerId:long}")]
        public IActionResult GetCustomerById(long customerId)
        {
            return Ok(_customerService.GetCustomerById(customerId));
        }
        
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            return Ok(_customerService.AddCustomer(customer));
        }

        [HttpPut("{customerId:long}")]
        public IActionResult UpdateCustomer(long customerId, Customer customer)
        {
            return Ok(_customerService.UpdateCustomer(customerId, customer));
        }

        [HttpDelete("{customerId:long}")]
        public IActionResult DeleteCustomer(long customerId)
        {
            return Ok(_customerService.DeleteCustomer(customerId));
        }
    }
}

