using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.Accounts.Queries.GetAccountsList
{
    public class GetAccountsListQuery : IRequest<List<AccountsVm>>
    {
        public GetAccountsListQuery()
        {
        }
    }
}
