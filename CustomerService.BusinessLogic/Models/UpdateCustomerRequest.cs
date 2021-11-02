namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Запрос на обновление пользователя
    /// </summary>
    public class UpdateCustomerRequest
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