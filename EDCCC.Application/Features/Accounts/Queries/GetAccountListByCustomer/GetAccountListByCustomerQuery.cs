using EDCCC.Application.Features.Accounts.Queries.GetAccountsList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.Accounts.Queries.GetAccountListByCustomer
{
    public class GetAccountListByCustomerQuery : IRequest<List<AccountsVm>>
    {
        public int _customerId { set; get; }

        public GetAccountListByCustomerQuery(int customerId)
        {
            _customerId = customerId;
        }
    }
}
