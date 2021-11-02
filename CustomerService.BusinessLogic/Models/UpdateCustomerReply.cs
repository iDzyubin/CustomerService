namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Ответ на запрос на обновление пользователя
    /// </summary>
    public class UpdateCustomerReply
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