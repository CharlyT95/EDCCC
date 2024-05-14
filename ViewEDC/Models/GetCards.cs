using System.Text.Json.Serialization;

namespace ViewEDC.Models
{
    public class GetCards
    {
        [JsonPropertyName("cNumber")]
        public string? cNumber { get; set; }

        [JsonPropertyName("dueDate")]
        public DateTime? dueDate { get; set; }

        [JsonPropertyName("limit")]
        public double? limit { get; set; }
    }
}
