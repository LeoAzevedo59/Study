using System.Text.Json.Serialization;

namespace Communication.Responses.Expense;

public class ResponseCreateExpenseJson
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
}