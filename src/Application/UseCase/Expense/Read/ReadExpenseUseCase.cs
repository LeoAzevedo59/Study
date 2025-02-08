using AutoMapper;
using Communication.Responses.Expense;
using Domain.Repositories;

namespace Application.useCase.Expense.Read;

public class ReadExpenseUseCase(
    IMapper mapper,
    IExpenseRepository expenseRepository
    ) : IReadExpenseUseCase
{
    public async Task<List<ResponseReadExpensesJson>> Execute()
    {
        var result = await expenseRepository.Get();
        
        var response = mapper.Map<List<ResponseReadExpensesJson>>(result);
        return response;
    }
}