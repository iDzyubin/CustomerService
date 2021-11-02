namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Запрос на добавление пользователя
    /// </summary>
    public class AddCustomerRequest
    {
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