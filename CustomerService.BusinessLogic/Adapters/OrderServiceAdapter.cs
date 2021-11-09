using CustomerService.BusinessLogic.Models;
using CustomerService.Contract.Messages;
using NatsExtensions.Services;

namespace CustomerService.BusinessLogic.Adapters
{
    public class OrderServiceAdapter : IOrderServiceAdapter
    {
        private readonly INatsService _natsService;

        public OrderServiceAdapter(INatsService natsService)
        {
            _natsService = natsService;
        }

        public GetOrdersByCustomerIdReply GetOrdersByCustomerId(GetOrdersByCustomerIdRequest request)
        {
            return _natsService.RequestReply<GetOrdersByCustomerIdRequest, GetOrdersByCustomerIdReply>(
                request: request, 
                subject: ServiceBusSubjects.OrderSubject);
        }
    }
}