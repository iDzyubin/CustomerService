using CustomerService.BusinessLogic.Models;

namespace CustomerService.BusinessLogic.Adapters
{
    /// <summary>
    /// Адаптер для общения с сервисом заказов
    /// </summary>
    public interface IOrderServiceAdapter
    {
        /// <summary>
        ///     Получить заказы конкретного покупателя
        /// </summary>
        /// <param name="request">Тело запроса </param>
        /// <returns>Ответ на запрос</returns>
        GetOrdersByCustomerIdReply GetOrdersByCustomerId(GetOrdersByCustomerIdRequest request);
    }
}