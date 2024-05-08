using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.CCards.Queries.GetCCardsList
{
    public class GetCCardsListQuery : IRequest<List<CCardsVm>>
    {
        public GetCCardsListQuery()
        {
        }
    }
}
