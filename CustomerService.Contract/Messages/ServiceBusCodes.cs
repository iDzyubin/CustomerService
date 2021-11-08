namespace CustomerService.Contract.Messages
{
    /// <summary>
    ///     Коды взаимодействия с шиной данных
    /// </summary>
    public class ServiceBusCodes
    {
        public const int GetCustomersRequest = 10001;
        
        public const int GetCustomersReply = 10002;
    }
}