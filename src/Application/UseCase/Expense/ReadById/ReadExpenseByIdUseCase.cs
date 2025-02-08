using AutoMapper;
using Communication.Responses.Expense;
using Domain.Repositories;
using Exception.Exceptions;

namespace Application.useCase.Expense.ReadById;

public class ReadExpenseByIdUseCase(
    IMapper mapper,
    IExpenseRepository repository
    ) : IReadExpenseByIdUseCase
{
    public async Task<ResponseReadExpenseJson> Execute(Guid expenseId)
    {
        var result = await repository.GetById(expenseId);

        if (result is null)
            throw new NotFoundException("Despesa não encontrada.");
                
        var response = mapper.Map<ResponseReadExpenseJson>(result);

        return response;
    }
}