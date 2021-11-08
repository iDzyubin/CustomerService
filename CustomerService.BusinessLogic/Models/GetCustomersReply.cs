using System.Collections.Generic;
using CustomerService.Contract.Entities;
using CustomerService.Contract.Messages;
using NatsExtensions.Attributes;
using NatsExtensions.Models;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Ответ на запрос на получение всех пользователей
    /// </summary>
    [ServiceBus(Code = ServiceBusCodes.GetCustomersReply)]
    public class GetCustomersReply : Reply
    {
        /// <summary>
        /// Покупатели
        /// </summary>
        public List<Customer> Customers { get; set; }
    } 
}