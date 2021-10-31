using System.Collections.Generic;
using CustomerService.Contract.Entities;

namespace CustomerService.Contract.Interfaces
{
    /// <summary>
    ///     Интерфейс для взаимодействия с сервисом покупателя
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        ///     Добавить нового покупателя в систему
        /// </summary>
        /// <param name="customer">Данные о добавляемом покупателе</param>
        /// <returns></returns>
        Customer AddCustomer(Customer customer);

        /// <summary>
        ///     Обновить информацию об уже имеющемся покупателе
        /// </summary>
        /// <param name="customerId">Идентификатор покупателя, которого обновляем</param>
        /// <param name="customer">Обновленная информация</param>
        /// <returns>Обновленная информация о покупателе</returns>
        Customer UpdateCustomer(long customerId, Customer customer);

        /// <summary>
        ///     Удалить покупателя из системы
        /// </summary>
        /// <param name="customerId">Идентификатор покупателя, которого удаляем</param>
        /// <returns>Информация об удаленном покупателе</returns>
        Customer DeleteCustomer(long customerId);

        /// <summary>
        ///     Получить покупателя по идентификатору
        /// </summary>
        /// <param name="customerId">Идентификатор покупателя</param>
        /// <returns>Искомый покупатель</returns>
        Customer GetCustomerById(long customerId);

        /// <summary>
        ///     Вернуть всех покупателей
        /// </summary>
        /// <returns>Коллекция покупателей</returns>
        List<Customer> GetAllCustomers();
    }
}