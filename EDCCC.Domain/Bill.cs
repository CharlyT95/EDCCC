namespace EDCCC.Domain
{
    public class Bill : BaseDomainModel
    {
        public string Description { get; set; }

        public double Amount { get; set; }

        public int CCardId { get; set; }
        public virtual CCard CCards { get; set; }
        public int TransactionTypeId { get; set; }
        public virtual TransactionType TransactionTypes { get; set; }

    }
}
