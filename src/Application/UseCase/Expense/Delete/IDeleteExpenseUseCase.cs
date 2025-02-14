namespace Application.UseCase.Expense.Delete
{
    public interface IDeleteExpenseUseCase
    {
        Task Execute(Guid expenseId);
    }
}
