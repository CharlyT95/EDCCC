using EDCCC.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.Accounts.Commands.CreateAccounts
{
    public class CreateAccountsCommand : IRequest<int>
    {
        public int Number { set; get; }
        public int TypeAccountId { set; get; }
        public int CustomerId { set; get; }
    }
}
