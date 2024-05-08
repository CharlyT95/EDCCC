namespace EDCCC.Domain
{
    public abstract class BaseDomainModel
    {

        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime? ModifyDate { get; set; }

    }
}
