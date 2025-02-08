using AutoMapper;
using Communication.Responses.Expense;
using Domain.Repositories;

namespace Application.useCase.Expense.ReadById;

public class ReadExpenseByIdUseCase(
    IMapper mapper,
    IExpenseRepository repository
    ) : IReadExpenseByIdUseCase
{
    public async Task<ResponseReadExpenseJson?> Execute(Guid expenseId)
    {
        var result = await repository.GetById(expenseId);

        if (result is null)
            return null;
                
        var response = mapper.Map<ResponseReadExpenseJson>(result);

        return response;
    }
}