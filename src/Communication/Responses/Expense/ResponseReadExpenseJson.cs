using Domain.Enums;
using System.Text.Json.Serialization;

namespace Communication.Responses.Expense
{
    public class ResponseReadExpenseJson
    {
        [JsonPropertyName("id")] public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("amount")] public decimal Amount { get; set; }

        [JsonPropertyName("movement_at")]
        public DateTime MovementAt { get; set; }

        [JsonPropertyName("payment_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PaymentType Payment { get; set; }
    }
}
