namespace EDCCC.Application.Features.Bills.Queries.GetBillsList
{
    public class BillVm
    {
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int AccountID { get; set; }


        public int CCardId { get; set; }
    }
}
