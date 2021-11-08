using System.Threading.Tasks;
using AutoMapper;
using CustomerService.BusinessLogic.Models;
using CustomerService.Contract.Interfaces;
using NatsExtensions.Handlers;

namespace CustomerService.Application.Handlers
{
    /// <summary>
    ///     Обработчик на получение данных покупателей
    /// </summary>
    public class GetCustomersHandler : IHandler<GetCustomersRequest, GetCustomersReply>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public GetCustomersHandler(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        public async Task<GetCustomersReply> Handle(GetCustomersRequest request)
        {
            var customers = _customerService.GetAllCustomers();
            return await Task.FromResult(_mapper.Map<GetCustomersReply>(customers));
        }
    }
}