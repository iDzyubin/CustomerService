using System.Collections.Generic;
using CustomerService.Contract.Entities;
using CustomerService.Contract.Messages;
using NatsExtensions.Attributes;
using NatsExtensions.Models;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    ///     Ответ на запрос по получению покупателей с информацией по их заказам
    /// </summary>
    [ServiceBus(Code = ServiceBusCodes.GetCustomerWithOrdersByIdReply)]
    public class GetCustomerWithOrdersByIdReply : Reply
    {
        /// <summary>
        ///     Информация о покупателе
        /// </summary>
        public Customer Customer { get; set; }
        
        /// <summary>
        ///     Заказы покупателя
        /// </summary>
        public IEnumerable<Order> Orders { get; set; }
    }
}