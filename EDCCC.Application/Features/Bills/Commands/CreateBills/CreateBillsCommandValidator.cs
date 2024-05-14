using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.Bills.Commands.CreateBills
{
    public class CreateBillsCommandValidator : AbstractValidator<CreateBillsCommand>
    {
        public CreateBillsCommandValidator()
        {
            RuleFor(b => b.Amount).NotNull().WithMessage("{Amount} no puede ser nulo");
            RuleFor(b => b.Description).NotNull().WithMessage("{Description} no puede ser nulo").NotEmpty().WithMessage("{Description} debe contener descripcion");
            RuleFor(b => b.CCardId).NotNull().WithMessage("{CCardId} NO PUEDE SER NULO");
        }
    }
}
