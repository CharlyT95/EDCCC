using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.CCards.Command.UpdateCCard
{
    public class UpdateCCardCommandHandlerValidator : AbstractValidator<UpdateCCardCommand>
    {
        public UpdateCCardCommandHandlerValidator()
        {

            RuleFor(c => c.InterestRate).NotEmpty().WithMessage("Debe ingresar el interes").LessThan(0).WithMessage("{InterestRate} Debe ser mayor a 0").GreaterThan(0).WithMessage("{InterestRate} Debe ser mayor a 0");
        }
    }
}
