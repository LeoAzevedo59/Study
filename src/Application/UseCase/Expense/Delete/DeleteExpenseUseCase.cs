using Domain.Repositories;
using Domain.Repositories.Expenses;
using Exception.Exceptions;

namespace Application.UseCase.Expense.Delete;

public class DeleteExpenseUseCase(
    IExpenseWriteOnlyRepository expenseWriteOnlyRepository,
    IUnityOfWork unityOfWork
    ) : IDeleteExpenseUseCase
{
    public async Task Execute(Guid expenseId)
    {
        var expenseWasDeleted = await expenseWriteOnlyRepository.Delete(expenseId);
        
        if (!expenseWasDeleted)
            throw new NotFoundException("Despesa não encontrada.", "Valide o identificador da despesa.");
        
        await unityOfWork.Commit();
    }
}