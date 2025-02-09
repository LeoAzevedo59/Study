using AutoMapper;
using Communication.Responses.Expense;
using Domain.Repositories;
using Domain.Repositories.Expenses;
using Exception.Exceptions;

namespace Application.useCase.Expense.ReadById;

public class ReadExpenseByIdUseCase(
    IMapper mapper,
    IExpenseReadOnlyRepository repository
    ) : IReadExpenseByIdUseCase
{
    public async Task<ResponseReadExpenseJson> Execute(Guid expenseId)
    {
        var result = await repository.GetById(expenseId);

        if (result is null)
            throw new NotFoundException("Despesa não encontrada.", "Valide o identificador da despesa.");
                
        var response = mapper.Map<ResponseReadExpenseJson>(result);

        return response;
    }
}