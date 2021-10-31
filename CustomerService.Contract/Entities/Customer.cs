namespace CustomerService.Contract.Entities
{
    /// <summary>
    ///     Сущность покупателя
    /// </summary>
    public class Customer
    {
        /// <summary>
        ///     Идентификатор покупателя
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        ///     Имя
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        ///     Фамилия
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        ///     Отчество
        /// </summary>
        public string MiddleName { get; set; }
    }
}