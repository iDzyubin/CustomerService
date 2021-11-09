using CustomerService.Contract.Messages;
using NatsExtensions.Attributes;
using NatsExtensions.Models;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    ///     Запрос на получение информации о покупателе и его заказам
    /// </summary>
    [ServiceBus(Code = ServiceBusCodes.GetCustomerWithOrdersByIdRequest)]
    public class GetCustomerWithOrdersByIdRequest : Request
    {
        /// <summary>
        ///     Идентификатор покупателя
        /// </summary>
        public long CustomerId { get; set; }
    }
}