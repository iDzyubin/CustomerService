using CustomerService.Contract.Messages;
using NatsExtensions.Attributes;
using NatsExtensions.Models;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Запрос на получение покупателя
    /// </summary>
    [ServiceBus(Code = ServiceBusCodes.GetCustomerByIdRequest)]
    public class GetCustomerByIdRequest : Request
    {
        /// <summary>
        /// Идентификатор искомого покупателя
        /// </summary>
        public long Id { get; set; }
    }
}