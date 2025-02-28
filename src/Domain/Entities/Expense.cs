using Domain.Enums;

namespace Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime MovementAt { get; set; }
        public decimal Amount { get; set; }
        public PaymentType Payment { get; set; }
        public Guid UserId { get; set; }
        public required User User { get; set; }
    }
}
