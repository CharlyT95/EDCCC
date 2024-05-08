using EDCCC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.Accounts.Queries.GetAccountsList
{
    public class AccountsVm
    {
        public int Number { set; get; }
        public int TypeAccountId { set; get; }

        public int CustomerId { set; get; }
    }
}
