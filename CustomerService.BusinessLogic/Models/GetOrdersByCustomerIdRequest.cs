using CustomerService.Contract.Messages;
using NatsExtensions.Attributes;
using NatsExtensions.Models;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    ///     Запрос на получение товаров указанного покупателя
    /// </summary>
    [ServiceBus(Code = ServiceBusCodes.GetOrdersByCustomerIdRequest)]
    public class GetOrdersByCustomerIdRequest : Request
    {
        /// <summary>
        ///     Идентификатор покупателя
        /// </summary>
        public long CustomerId { get; set; }
    }
}