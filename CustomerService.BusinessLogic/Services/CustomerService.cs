using System;
using System.Collections.Generic;
using System.Linq;
using CustomerService.BusinessLogic.Contexts;
using CustomerService.Contract.Entities;
using CustomerService.Contract.Interfaces;

namespace CustomerService.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer AddCustomer(Customer customer)
        {
            var result = _context.Customers.Add(customer);
            _context.SaveChanges();
            return result.Entity;
        }

        public Customer UpdateCustomer(long customerId, Customer customer)
        {
            var entity = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (entity == null)
            {
                throw new InvalidOperationException("Пользователь с данным идентификатором отсутствует");
            }

            entity.FirstName = customer.FirstName;
            entity.LastName = customer.LastName;
            entity.MiddleName = customer.MiddleName;

            var result = _context.Customers.Update(entity);
            _context.SaveChanges();

            return result.Entity;
        }

        public Customer DeleteCustomer(long customerId)
        {
            var entity = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (entity == null)
            {
                throw new InvalidOperationException("Пользователь с данным идентификатором отсутствует");
            }

            var result = _context.Customers.Remove(entity);
            _context.SaveChanges();
            
            return result.Entity;
        }

        public Customer GetCustomerById(long customerId)
        {
            var entity = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (entity == null)
            {
                throw new InvalidOperationException("Пользователь с данным идентификатором отсутствует");
            }

            return entity;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}