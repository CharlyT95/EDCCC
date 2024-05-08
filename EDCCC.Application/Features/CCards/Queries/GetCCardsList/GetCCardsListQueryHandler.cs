using AutoMapper;
using EDCCC.Application.Contracts.Persistence;
using EDCCC.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.CCards.Queries.GetCCardsList
{
    public class GetCCardsListQueryHandler : IRequestHandler<GetCCardsListQuery, List<CCardsVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCCardsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CCardsVm>> Handle(GetCCardsListQuery request, CancellationToken cancellationToken)
        {
            var CCardList = await _unitOfWork.Repository<CCard>().GetAllAsync();


            return _mapper.Map<List<CCardsVm>>(CCardList.ToList());

        }
    }
}
