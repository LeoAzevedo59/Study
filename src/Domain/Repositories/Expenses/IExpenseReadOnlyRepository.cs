using Domain.Entities;

namespace Domain.Repositories.Expenses
{
    public interface IExpenseReadOnlyRepository
    {
        Task<List<Expense>> Get();
        Task<Expense?> GetById(Guid expenseId);
    }
}
