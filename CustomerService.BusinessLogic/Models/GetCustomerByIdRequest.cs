namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Запрос на получение покупателя
    /// </summary>
    public class GetCustomerByIdRequest
    {
        /// <summary>
        /// Идентификатор искомого покупателя
        /// </summary>
        public long Id { get; set; }
    }
}