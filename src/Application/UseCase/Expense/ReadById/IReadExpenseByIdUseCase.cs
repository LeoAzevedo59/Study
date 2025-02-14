using Communication.Responses.Expense;

namespace Application.useCase.Expense.ReadById
{
    public interface IReadExpenseByIdUseCase
    {
        Task<ResponseReadExpenseJson> Execute(Guid expenseId);
    }
}
