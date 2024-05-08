using EDCCC.Application.Features.Bills.Queries.GetBillsList;
using MediatR;

namespace EDCCC.Application.Features.Bills.Queries.GetBillsListByCCard
{
    public class GetBillsListByCCardQuery : IRequest<List<BillVm>>
    {
        public int _cCardId { get; set; }

        public GetBillsListByCCardQuery(int cCardId)
        {
            _cCardId = cCardId;
        }
    }
}
