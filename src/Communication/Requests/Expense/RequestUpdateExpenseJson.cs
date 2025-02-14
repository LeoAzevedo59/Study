using System.Text.Json.Serialization;

namespace Communication.Requests.Expense
{
    public class RequestUpdateExpenseJson
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("amount")] public decimal Amount { get; set; }

        [JsonPropertyName("movement_at")]
        public DateTime MovementAt { get; set; }
    }
}
