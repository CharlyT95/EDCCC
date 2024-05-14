namespace EDCCC.Application.Features.Bills.Queries.GetBillsList
{
    public class BillVm
    {

        public int Id { get; set; }
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int AccountID { get; set; }
        public DateTime Date { get; set; }
        public int TransactionTypeId { get; set; }
        public int CCardId { get; set; }
    }
}
