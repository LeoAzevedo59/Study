using Communication.Responses.Expense;
using Domain.Repositories.Expenses;
using Exception.Exceptions;

namespace Application.useCase.Expense.ReadById
{
    internal class ReadExpenseByIdUseCase(
        IExpenseReadOnlyRepository repository
    ) : IReadExpenseByIdUseCase
    {
        public async Task<ResponseReadExpenseJson> Execute(Guid expenseId)
        {
            Domain.Entities.Expense? result =
                await repository.GetById(expenseId);

            if (result is null)
            {
                throw new NotFoundException("Despesa não encontrada.",
                    "Valide o identificador da despesa.");
            }

            ResponseReadExpenseJson response = new(result.Id, result.Title,
                result.Description, result.Amount, result.MovementAt,
                result.Payment);

            return response;
        }
    }
}
