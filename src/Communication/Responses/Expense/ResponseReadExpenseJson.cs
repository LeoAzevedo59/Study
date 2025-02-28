using Domain.Enums;

namespace Communication.Responses.Expense
{
    public record ResponseReadExpenseJson(
        Guid Id,
        string Title,
        string Description,
        decimal Amount,
        DateTime MovementAt,
        PaymentType Payment
    );
}
