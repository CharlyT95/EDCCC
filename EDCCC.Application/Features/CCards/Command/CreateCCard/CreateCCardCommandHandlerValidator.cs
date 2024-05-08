using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.CCards.Command.CreateCCard
{
    public class CreateCCardCommandHandlerValidator : AbstractValidator<CreateCCardCommand>
    {
        public CreateCCardCommandHandlerValidator()
        {
            RuleFor(c => c.AccountId).NotEmpty().WithMessage("{AccountId} Tarjeta debe estar ligada a una cuenta").NotNull();
            RuleFor(c => c.CNumber).NotEmpty().WithMessage("{CNumber} Debe ingreser numero de tarjeta") .NotNull()
                .MaximumLength(16).WithMessage("Numero de tarjeta debe de ser de 16 caracteres");
            RuleFor(c => c.DueDate).NotEmpty().WithMessage("{DueDate} Fecha de expiracion es obligatorio").NotNull();
            RuleFor(c => c.InterestRate).NotEmpty().WithMessage("{InterestRate} Intereses es obligatorio").NotNull();
         

        }
    }
}
