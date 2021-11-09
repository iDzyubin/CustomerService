using System.Collections.Generic;
using CustomerService.Contract.Messages;
using NatsExtensions.Attributes;
using NatsExtensions.Models;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    ///     Ответ на запрос заказов для указанного покупателя
    /// </summary>
    [ServiceBus(Code = ServiceBusCodes.GetOrdersByCustomerIdReply)]
    public class GetOrdersByCustomerIdReply : Reply
    {   
        /// <summary>
        ///     Идентификатор покупателя
        /// </summary>
        public long CustomerId { get; set; }
        
        /// <summary>
        ///     Набор товаров указанного покупателя
        /// </summary>
        public IReadOnlyCollection<Order> Orders { get; set; }
    }
}