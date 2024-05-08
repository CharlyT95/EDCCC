using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using MediatR;
using EDCCC.Domain;

namespace EDCCC.Application.Features.Accounts.Queries.GetAccountsList
{
    public class GetAccountsListQueryHandler : IRequestHandler<GetAccountsListQuery, List<AccountsVm>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccountsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AccountsVm>> Handle(GetAccountsListQuery request, CancellationToken cancellationToken)
        {
            var AccountList = await _unitOfWork.Repository<Account>().GetAllAsync();

            return _mapper.Map<List<AccountsVm>>(AccountList.ToList());
        }
    }
}
