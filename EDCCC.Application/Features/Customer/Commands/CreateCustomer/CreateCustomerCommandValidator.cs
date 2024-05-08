using FluentValidation;

namespace EDCCC.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Debe ingresar nombre").NotNull().MinimumLength(0).WithMessage("Debe ingresar nombre");
        }
    }
}
