using Communication.Responses.Expense;

namespace Application.useCase.Expense.Read
{
    public interface IReadExpenseUseCase
    {
        Task<List<ResponseReadExpensesJson>> Execute();
    }
}
