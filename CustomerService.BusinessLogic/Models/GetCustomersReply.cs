using System.Collections.Generic;
using CustomerService.Contract.Entities;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Ответ на запрос на получение всех пользователей
    /// </summary>
    public class GetCustomersReply
    {
        /// <summary>
        /// Покупатели
        /// </summary>
        public List<Customer> Customers { get; set; }
    } 
}