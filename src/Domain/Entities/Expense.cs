using Domain.Enums;

namespace Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string? Description { get; init; }
        public DateTime MovementAt { get; init; }
        public decimal Amount { get; init; }
        public PaymentType Payment { get; init; }
        public Guid UserId { get; init; }
        public required User User { get; init; }
    }
}
