using Domain.Entities;

namespace Domain.Repositories.Expenses
{
    public interface IExpenseUpdateOnlyRepository
    {
        void Update(Expense expense);
        Task<Expense?> GetById(Guid id);
    }
}
