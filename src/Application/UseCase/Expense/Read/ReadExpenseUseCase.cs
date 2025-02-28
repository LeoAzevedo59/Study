using Communication.Responses.Expense;
using Domain.Repositories.Expenses;

namespace Application.useCase.Expense.Read
{
    internal class ReadExpenseUseCase(
        IExpenseReadOnlyRepository expenseRepository
    ) : IReadExpenseUseCase
    {
        public async Task<List<ResponseReadExpensesJson>> Execute()
        {
            List<Domain.Entities.Expense>
                results = await expenseRepository.Get();

            List<ResponseReadExpensesJson> response =
                results.Select(expense =>
                    new ResponseReadExpensesJson(expense.Id, expense.Title,
                        expense.Description, expense.Amount)).ToList();

            return response;
        }
    }
}
