namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    ///     Сущность товара
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public long OrderId { get; set; }
        
        /// <summary>
        ///     Наименование товара
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        ///     Цена товара в заказе
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        ///     Количество выбранного товара в заказе
        /// </summary>
        public int Count { get; set; }
    }
}