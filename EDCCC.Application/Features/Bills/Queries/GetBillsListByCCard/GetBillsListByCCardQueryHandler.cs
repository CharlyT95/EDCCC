using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using EDCCC.Application.Features.Bills.Queries.GetBillsList;
using EDCCC.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.Bills.Queries.GetBillsListByCCard
{
    public class GetBillsListByCCardQueryHandler : IRequestHandler<GetBillsListByCCardQuery, List<BillVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBillsListByCCardQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BillVm>> Handle(GetBillsListByCCardQuery request, CancellationToken cancellationToken)
        {
            var BillsList = await _unitOfWork.Repository<Bill>().GetAllAsync();

            return _mapper.Map<List<BillVm>>(BillsList.Where(b => b.CCardId == request._cCardId));
        }
    }
}
