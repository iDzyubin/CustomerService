namespace CustomerService.BusinessLogic.Models
{
    /// <summary>
    /// Ответ на запрос на получение покупателя
    /// </summary>
    public class GetCustomerByIdReply
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