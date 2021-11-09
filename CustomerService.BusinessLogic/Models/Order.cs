using System.Collections.Generic;

namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    ///     Модель заказа
    /// </summary>
    public class Order
    {
        /// <summary>
        ///     Идентификатор покупателя
        /// </summary>
        public long CustomerId { get; set; }
        
        /// <summary>
        ///     Сумма заказа
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        ///     Позиции товаров в заказе
        /// </summary>
        public List<Product> Products { get; set; }
    }
}