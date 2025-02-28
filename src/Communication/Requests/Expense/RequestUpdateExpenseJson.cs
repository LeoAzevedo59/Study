namespace Communication.Requests.Expense
{
    public record RequestUpdateExpenseJson(
        string Title,
        string Description,
        decimal Amount,
        DateTime MovementAt
    );
}
