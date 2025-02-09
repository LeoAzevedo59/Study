using Communication.Requests.Expense;

namespace Application.UseCase.Expense.Update;

public interface IUpdateExpenseUseCase
{
    Task Execute(Guid expenseId, RequestUpdateExpenseJson request);
}