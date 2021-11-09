using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerService.BusinessLogic.Contexts;
using CustomerService.Contract.Entities;
using CustomerService.Contract.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _context;

        public CustomerService(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var result = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            if (!await _context.Customers.AnyAsync(c => c.Id == customer.Id))
            {
                throw new InvalidOperationException("Пользователь с данным идентификатором отсутствует");
            }

            var result = _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Customer> DeleteCustomerAsync(long customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Пользователь с данным идентификатором отсутствует");
            }

            var result = _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            
            return result.Entity;
        }

        public async Task<Customer> GetCustomerByIdAsync(long customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Пользователь с данным идентификатором отсутствует");
            }

            return customer;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}