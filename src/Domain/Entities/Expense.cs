using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Entities;

[Table("expenses")]
public class Expense
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("movement_at")]
    public DateTime MovementAt { get; set; }
    
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
    
    [JsonPropertyName("payment_type")]
    public PaymentType PaymentType { get; set; }
}