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
        public long FirstName { get; set; }
        
        /// <summary>
        ///     Фамилия
        /// </summary>
        public long LastName { get; set; }
        
        /// <summary>
        ///     Отчество
        /// </summary>
        public long MiddleName { get; set; }
    }
}