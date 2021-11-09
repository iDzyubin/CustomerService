using CustomerService.Contract.Messages;
using NatsExtensions.Attributes;
using NatsExtensions.Models;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Ответ на запрос на получение покупателя
    /// </summary>
    [ServiceBus(Code = ServiceBusCodes.GetCustomerByIdReply)]
    public class GetCustomerByIdReply : Reply
    {
        /// <summary>
        /// Идентификатор покупателя
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
    }
}