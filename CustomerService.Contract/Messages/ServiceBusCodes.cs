namespace CustomerService.Contract.Messages
{
    /// <summary>
    ///     Коды взаимодействия с шиной данных
    /// </summary>
    public class ServiceBusCodes
    {
        #region Customer Service Codes

        /// <summary>
        /// Запрос на добавление покупателя
        /// </summary>
        public const int AddCustomerRequest = 10001;

        /// <summary>
        /// Ответ на запрос на добавление покупателя
        /// </summary>
        public const int AddCustomerReply = 10002;
        
        /// <summary>
        /// Запрос на добавление покупателя
        /// </summary>
        public const int DeleteCustomerRequest = 10003;

        /// <summary>
        /// Ответ на запрос на удаление покупателя
        /// </summary>
        public const int DeleteCustomerReply = 10004;
        
        /// <summary>
        /// Запрос на обновление покупателя
        /// </summary>
        public const int UpdateCustomerRequest = 10005;

        /// <summary>
        /// Ответ на запрос на обновление покупателя
        /// </summary>
        public const int UpdateCustomerReply = 10006;
        
        /// <summary>
        /// Запрос на получение покупателя
        /// </summary>
        public const int GetCustomerByIdRequest = 10007;

        /// <summary>
        /// Ответ на запрос на получение покупателя
        /// </summary>
        public const int GetCustomerByIdReply = 10008;
        
        /// <summary>
        /// Запрос на получение всех пользователей
        /// </summary>
        public const int GetCustomersRequest = 10009;

        /// <summary>
        /// Ответ на запрос на получение всех пользователей
        /// </summary>
        public const int GetCustomersReply = 10010;
        
        /// <summary>
        ///     Запрос на получение информации о покупателе и его заказам
        /// </summary>
        public const int GetCustomerWithOrdersByIdRequest = 10011;

        /// <summary>
        ///     Ответ на запрос по получению покупателей с информацией по их заказам
        /// </summary>
        public const int GetCustomerWithOrdersByIdReply = 10012;

        #endregion
        
        
        #region Order Service Codes

        /// <summary>
        ///     Запрос на создание заказа
        /// </summary>
        public const int CreateOrderRequest = 20001;

        /// <summary>
        ///     Ответ на запрос о добавлении заказа
        /// </summary>
        public const int CreateOrderReply = 20002;
        
        /// <summary>
        ///     Запрос на удаление заказа
        /// </summary>
        public const int DeleteOrderRequest = 20003;

        /// <summary>
        ///     Ответ на удалении заказа
        /// </summary>
        public const int DeleteOrderReply = 20004;
        
        /// <summary>
        ///     Запрос на получение заказа
        /// </summary>
        public const int GetOrderByIdRequest = 20005;

        /// <summary>
        ///     Ответ на запрос о получении заказа
        /// </summary>
        public const int GetOrderByIdReply = 20006;
        
        /// <summary>
        ///     Запрос на получение товаров указанного покупателя
        /// </summary>
        public const int GetOrdersByCustomerIdRequest = 20007;

        /// <summary>
        ///     Ответ на запрос заказов для указанного покупателя
        /// </summary>
        public const int GetOrdersByCustomerIdReply = 20008;
        
        /// <summary>
        ///     Запрос на получение товаров указанного покупателя
        /// </summary>
        public const int GetOrdersRequest = 20009;

        /// <summary>
        ///     Ответ на запрос о получении всех заказов
        /// </summary>
        public const int GetOrdersReply = 20010;
        
        /// <summary>
        ///     Запрос на обновление информации по заказу
        /// </summary>
        public const int UpdateOrderRequest = 20011;

        /// <summary>
        ///     Ответ на запрос об обновлении информации по заказу
        /// </summary>
        public const int UpdateOrderReply = 20012;
        
        #endregion
    }
}