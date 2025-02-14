using System.Text.Json.Serialization;

namespace Communication.Responses.Expense
{
    public class ResponseReadExpensesJson
    {
        [JsonPropertyName("id")] public Guid Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("amount")] public decimal Amount { get; set; }
    }
}
