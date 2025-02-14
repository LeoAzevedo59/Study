using AutoMapper;
using Communication.Responses.Expense;
using Domain.Repositories.Expenses;

namespace Application.useCase.Expense.Read
{
    public class ReadExpenseUseCase(
        IMapper mapper,
        IExpenseReadOnlyRepository expenseRepository
    ) : IReadExpenseUseCase
    {
        public async Task<List<ResponseReadExpensesJson>> Execute()
        {
            List<Domain.Entities.Expense>
                result = await expenseRepository.Get();

            List<ResponseReadExpensesJson>? response =
                mapper.Map<List<ResponseReadExpensesJson>>(result);
            return response;
        }
    }
}
