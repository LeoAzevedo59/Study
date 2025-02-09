using AutoMapper;
using Communication.Responses.Expense;
using Domain.Repositories;
using Domain.Repositories.Expenses;

namespace Application.useCase.Expense.Read;

public class ReadExpenseUseCase(
    IMapper mapper,
    IExpenseReadOnlyRepository expenseRepository
    ) : IReadExpenseUseCase
{
    public async Task<List<ResponseReadExpensesJson>> Execute()
    {
        var result = await expenseRepository.Get();
        
        var response = mapper.Map<List<ResponseReadExpensesJson>>(result);
        return response;
    }
}