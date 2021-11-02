namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Запрос на удаление покупателя
    /// </summary>
    public class DeleteCustomerRequest
    {
        /// <summary>
        /// Идентификатор удаляемого покупателя
        /// </summary>
        public long Id { get; set; }
    }
}