namespace Communication.Responses.Expense
{
    public record ResponseReadExpensesJson(
        Guid Id,
        string Title,
        string Description,
        decimal Amount
    );
}
