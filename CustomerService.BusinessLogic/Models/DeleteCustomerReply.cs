namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Ответ на запрос на удаление покупателя
    /// </summary>
    public class DeleteCustomerReply
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