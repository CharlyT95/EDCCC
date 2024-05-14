namespace WebMVCEDCCC.Models
{
    public class Bills
    {
        public int id { get; set; }
        public string description { get; set; }

        public double amount { get; set; }

        public int cCardId { get; set; }

        public int transactionTypeId { get; set; }

        public DateTime date { get; set; }
    }
}
