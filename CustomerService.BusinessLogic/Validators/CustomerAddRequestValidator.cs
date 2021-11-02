using CustomerService.BusinessLogic.Models;
using FluentValidation;

namespace CustomerService.BusinessLogic.Validators
{
    public class CustomerAddRequestValidator : AbstractValidator<AddCustomerRequest>
    {
        public CustomerAddRequestValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Запрос не может быть пустым");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Поле 'Имя' не может быть пустым");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Поле 'Фамилия' не может быть пустым");
        }
    }
}