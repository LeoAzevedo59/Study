using Domain.Entities;

namespace Domain.Repositories.Expenses;

public interface IExpenseWriteOnlyRepository
{
    Task Add(Expense expense);
}