using System;
using AutoMapper;
using CustomerService.BusinessLogic.Models;
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
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<GetCustomersReply> GetCustomers(GetCustomersRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _customerService.GetAllCustomers();
                return Ok(_mapper.Map<GetCustomersReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public ActionResult<GetCustomerByIdReply> GetCustomerById(GetCustomerByIdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = _customerService.GetCustomerById(request.Id);
                return Ok(_mapper.Map<GetCustomerByIdReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        
        [HttpPost]
        public ActionResult<AddCustomerReply> AddCustomer(AddCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _customerService.AddCustomer(_mapper.Map<Customer>(request));
                return Ok(_mapper.Map<AddCustomerReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public ActionResult<UpdateCustomerReply> UpdateCustomer(UpdateCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _customerService.UpdateCustomer(request.Id, _mapper.Map<Customer>(request));
                return Ok(_mapper.Map<UpdateCustomerReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public ActionResult<DeleteCustomerReply> DeleteCustomer(DeleteCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = _customerService.DeleteCustomer(request.Id);
                return Ok(_mapper.Map<DeleteCustomerReply>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}

