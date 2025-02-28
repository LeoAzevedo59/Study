using Domain.Enums;

namespace Domain.Entities
{
    public class Expense
    {
        public Expense(string title, string description, DateTime movementAt,
            decimal amount, PaymentType payment, Guid userId)
        {
            Title = title;
            Description = description;
            MovementAt = movementAt;
            Amount = amount;
            Payment = payment;
            UserId = userId;
        }

        private Expense() { }

        public Expense(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public Guid Id { get; init; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime MovementAt { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentType Payment { get; private set; }
        public Guid UserId { get; private set; }
        public virtual User User { get; private set; } = null!;

        public static Expense Update(Expense expenseOld, string title,
            string description,
            decimal amount,
            DateTime movementAt)
        {
            expenseOld.Title = title;
            expenseOld.Description = description;
            expenseOld.Amount = amount;
            expenseOld.MovementAt = movementAt;

            return expenseOld;
        }
    }
}
