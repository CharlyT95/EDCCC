using MediatR;

namespace EDCCC.Application.Features.Bills.Queries.GetBillsList
{
    public class GetBillsListQuery : IRequest<List<BillVm>>
    {
        public GetBillsListQuery()
        {
        }
    }
}
