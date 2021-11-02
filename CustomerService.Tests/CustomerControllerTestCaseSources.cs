using System.Collections.Generic;
using CustomerService.BusinessLogic.Models;
using NUnit.Framework;

namespace CustomerService.Tests
{
    public static class CustomerControllerTestCaseSources
    {
        public static IEnumerable<TestCaseData> GetAddCustomerInvalidParameters()
        {
            yield return new TestCaseData(
                    null, 
                    null)
                .SetDescription("null argument");
            
            yield return new TestCaseData(
                    new AddCustomerRequest(),
                    new AddCustomerReply())
                .SetDescription("empty argument");
        }

        public static IEnumerable<TestCaseData> GetAddCustomerValidParameters()
        {
            yield return new TestCaseData(
                    new AddCustomerRequest
                    {
                        FirstName = "Алексей",
                        LastName = "Иванов",
                        MiddleName = "Дмитриевич"
                    },
                    new AddCustomerReply
                    {
                        FirstName = "Алексей",
                        LastName = "Иванов",
                        MiddleName = "Дмитриевич"
                    })
                .SetDescription("empty argument");
        }
    }
}