using CustomerService.BusinessLogic.Models;
using FluentValidation;

namespace CustomerService.BusinessLogic.Validators
{
    public class GetCustomerWithOrdersByIdRequestValidator : AbstractValidator<GetCustomerWithOrdersByIdRequest>
    {
        public GetCustomerWithOrdersByIdRequestValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("Некоректный идентификатор покупателя");
        }
    }
}