using CustomerService.BusinessLogic.Models;
using NatsExtensions.Proxies;
using NatsExtensions.Services;

namespace CustomerService.BusinessLogic.Proxies
{
    public class OrderServiceProxy : BaseProxy<GetOrdersByCustomerIdRequest, GetOrdersByCustomerIdReply>
    {
        public OrderServiceProxy(INatsService natsService) : base(natsService) { }
    }
}