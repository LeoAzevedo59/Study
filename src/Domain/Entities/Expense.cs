using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Entities;

[Table("expenses")]
public class Expense
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("title")]
    public string Title { get; set; } = string.Empty;
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("movement_at")]
    public DateTime MovementAt { get; set; }
    
    [Column("amount")]
    public decimal Amount { get; set; }
    
    [Column("payment")]
    public PaymentType Payment { get; set; }
}