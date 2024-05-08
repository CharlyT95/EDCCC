using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.Bills.Commands.CreateBills
{
    public class CreateBillsCommand : IRequest<int>
    {
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int CCardId { get; set; }


    }
}
