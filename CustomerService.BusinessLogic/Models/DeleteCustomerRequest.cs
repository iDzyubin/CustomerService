using CustomerService.Contract.Messages;
using NatsExtensions.Attributes;
using NatsExtensions.Models;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Запрос на удаление покупателя
    /// </summary>
    [ServiceBus(Code = ServiceBusCodes.DeleteCustomerRequest)]
    public class DeleteCustomerRequest : Request
    {
        /// <summary>
        /// Идентификатор удаляемого покупателя
        /// </summary>
        public long Id { get; set; }
    }
}