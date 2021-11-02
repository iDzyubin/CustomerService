using CustomerService.Contract.Entities;
using FluentValidation;

namespace CustomerService.BusinessLogic.Validators
{
    /// <summary>
    ///     Пустой валидатор за который будем биндить все остальные
    /// </summary>
    public class AnchorValidator : AbstractValidator<Customer>
    {
    }
}