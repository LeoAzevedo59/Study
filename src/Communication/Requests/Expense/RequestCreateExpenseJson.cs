using Communication.Enums;

namespace Communication.Requests.Expense
{
    public record RequestCreateExpenseJson(
        string Title,
        string Description,
        decimal Amount,
        DateTime MovementAt,
        PaymentType PaymentType);
}
