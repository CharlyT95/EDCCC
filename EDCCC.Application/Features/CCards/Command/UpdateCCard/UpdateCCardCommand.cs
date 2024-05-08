using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.CCards.Command.UpdateCCard
{
    public class UpdateCCardCommand : IRequest
    {
        public int Id { get; set; }
        public double Limit { get; set; }
        public double InterestRate { get; set; }
    }
}
