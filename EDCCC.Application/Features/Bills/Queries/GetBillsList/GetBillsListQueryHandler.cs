using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using EDCCC.Domain;
using MediatR;

namespace EDCCC.Application.Features.Bills.Queries.GetBillsList
{
    public class GetBillsListQueryHandler : IRequestHandler<GetBillsListQuery, List<BillVm>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBillsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BillVm>> Handle(GetBillsListQuery request, CancellationToken cancellationToken)
        {
            var BillList = await _unitOfWork.Repository<Bill>().GetAllAsync();

            return _mapper.Map<List<BillVm>>(BillList);
        }
    }
}
