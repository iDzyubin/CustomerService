using System.Collections.Generic;
using CustomerService.Contract.Entities;
using NUnit.Framework;

namespace CustomerService.Tests
{
    public static class CustomerServiceTestCaseSources
    {
        public static IEnumerable<TestCaseData> GetAddCustomerInvalidParameters()
        {
            yield return new TestCaseData(null)
                .SetDescription("Null argument");

            yield return new TestCaseData(new Customer
                {
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    MiddleName = string.Empty,
                })
                .SetDescription("Customer with empty fields");
        }
        
        public static IEnumerable<TestCaseData> GetAddCustomerValidParameters()
        {
            yield return new TestCaseData(new Customer
            {
                FirstName = "Алексей",
                LastName = "Иванов",
                MiddleName = "Дмитриевич"
            })
            .SetDescription("Valid argument");
        }
        
        public static IEnumerable<TestCaseData> GetUpdateCustomerInvalidParameters()
        {
            yield return new TestCaseData(0, null)
                .SetDescription("Invalid arguments");
            
            yield return new TestCaseData(1, null)
                .SetDescription("Null customer argument");
            
            yield return new TestCaseData(
                1, 
                new Customer
                {
                    FirstName = "Алексей",
                    LastName = "Иванов",
                    MiddleName = "Дмитриевич"
                })
                .SetDescription("Invalid customerId argument");

            yield return new TestCaseData(
                1,
                new Customer
                {
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    MiddleName = string.Empty,
                })
                .SetDescription("Customer with empty fields");
        }
        
        public static IEnumerable<TestCaseData> GetUpdateCustomerValidParameters()
        {
            yield return new TestCaseData(
                1,
                new Customer
                {
                    FirstName = "Алексей",
                    LastName = "Иванов",
                    MiddleName = "Дмитриевич"
                });
        }

        public static IEnumerable<TestCaseData> GetDeleteCustomerInvalidParameters()
        {
            yield return new TestCaseData(null).SetDescription("Null argument");
            yield return new TestCaseData(0).SetDescription("Invalid argument");
            yield return new TestCaseData(-1).SetDescription("Invalid argument");
        }

        public static IEnumerable<TestCaseData> GetDeleteCustomerValidParameters()
        {
            yield return new TestCaseData(
                1, 
                new Customer
                {
                    Id = 1, 
                    FirstName = "Алексей",
                    LastName = "Иванов",
                    MiddleName = "Дмитриевич"
                }).SetDescription("Valid argument");
        }
        
        public static IEnumerable<TestCaseData> GetCustomerByIdInvalidParameters()
        {
            yield return new TestCaseData(null).SetDescription("Null argument");
            yield return new TestCaseData(0).SetDescription("Invalid argument");
            yield return new TestCaseData(-1).SetDescription("Invalid argument");
        }

        public static IEnumerable<TestCaseData> GetCustomerByIdValidParameters()
        {
            yield return new TestCaseData(
                1, 
                new Customer
                {
                    Id = 1, 
                    FirstName = "Алексей",
                    LastName = "Иванов",
                    MiddleName = "Дмитриевич"
                }).SetDescription("Valid argument");
        }

        public static IEnumerable<TestCaseData> GetAllCustomersParameters()
        {
            yield return new TestCaseData(new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Иван", LastName = "Иванов", MiddleName = "Иванович" },
                new Customer { Id = 1, FirstName = "Петр", LastName = "Петров", MiddleName = "Петрович" },
            });
        }
    }
}