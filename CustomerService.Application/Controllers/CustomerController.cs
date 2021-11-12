using System;
using System.Threading.Tasks;
using AutoMapper;
using CustomerService.BusinessLogic.Models;
using CustomerService.Contract.Entities;
using CustomerService.Contract.Interfaces;
using CustomerService.Contract.Messages;
using Microsoft.AspNetCore.Mvc;
using NatsExtensions.Proxies;

namespace CustomerService.Application.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IProxy<GetOrdersByCustomerIdRequest, GetOrdersByCustomerIdReply> _orderServiceProxy;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(IProxy<GetOrdersByCustomerIdRequest, GetOrdersByCustomerIdReply> orderServiceProxy, ICustomerService customerService, IMapper mapper)
        {
            _orderServiceProxy = orderServiceProxy;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<GetCustomersReply>> GetCustomers(GetCustomersRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _customerService.GetAllCustomersAsync();
                return Ok(_mapper.Map<GetCustomersReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetCustomerWithOrdersByIdReply>> GetCustomerWithOrdersById(GetCustomerWithOrdersByIdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(request.CustomerId);
                if (customer == null)
                {
                    return BadRequest("Пользователь с указанным идентификатором не существует");
                }
                
                var reply = _orderServiceProxy.Execute(
                    request: new GetOrdersByCustomerIdRequest { CustomerId = request.CustomerId },
                    subject: ServiceBusSubjects.OrderSubject);
                
                return Ok(new GetCustomerWithOrdersByIdReply { Customer = customer, Orders = reply.Orders });
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetCustomerByIdReply>> GetCustomerById(GetCustomerByIdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _customerService.GetCustomerByIdAsync(request.Id);
                return Ok(_mapper.Map<GetCustomerByIdReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<AddCustomerReply>> AddCustomer(AddCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _customerService.AddCustomerAsync(_mapper.Map<Customer>(request));
                return Ok(_mapper.Map<AddCustomerReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<UpdateCustomerReply>> UpdateCustomer(UpdateCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _customerService.UpdateCustomerAsync(_mapper.Map<Customer>(request));
                return Ok(_mapper.Map<UpdateCustomerReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<DeleteCustomerReply>> DeleteCustomer(DeleteCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _customerService.DeleteCustomerAsync(request.Id);
                return Ok(_mapper.Map<DeleteCustomerReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}

