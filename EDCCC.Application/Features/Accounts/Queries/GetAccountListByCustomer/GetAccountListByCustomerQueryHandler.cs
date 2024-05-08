using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using EDCCC.Application.Features.Accounts.Queries.GetAccountsList;
using EDCCC.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.Accounts.Queries.GetAccountListByCustomer
{
    public class GetAccountListByCustomerQueryHandler : IRequestHandler<GetAccountListByCustomerQuery, List<AccountsVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccountListByCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AccountsVm>> Handle(GetAccountListByCustomerQuery request, CancellationToken cancellationToken)
        {
            var AccpuntList = await _unitOfWork.Repository<Account>().GetAllAsync();

            return _mapper.Map<List<AccountsVm>>(AccpuntList.Where(a => a.CustomerId == request._customerId));
        }
    }
}
