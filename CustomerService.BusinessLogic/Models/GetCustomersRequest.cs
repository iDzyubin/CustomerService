using CustomerService.Contract.Messages;
using NatsExtensions.Attributes;
using NatsExtensions.Models;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Запрос на получение всех пользователей
    /// </summary>
    [ServiceBus(Code = ServiceBusCodes.GetCustomersRequest)]
    public class GetCustomersRequest : Request
    {
    }
}