using System.Collections.Generic;
using AutoMapper;
using CustomerService.BusinessLogic.Models;
using CustomerService.Contract.Entities;

namespace CustomerService.BusinessLogic.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerRequest, Customer>();
            CreateMap<Customer, AddCustomerReply>();

            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<Customer, UpdateCustomerReply>();

            CreateMap<Customer, GetCustomerByIdReply>();
            
            CreateMap<IEnumerable<Customer>, GetCustomersReply>()
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src));
        }
    }
}