using System.Text.Json.Serialization;

namespace Domain.Enums;

public enum PaymentType
{
    [JsonPropertyName("cash")]
    Cash,
    [JsonPropertyName("credit_card")]
    CreditCard,
    [JsonPropertyName("debit_card")]
    DebitCard
}