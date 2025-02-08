using ExpenseEntity = Domain.Entities.Expense;
namespace Domain.Repositories.Expenses;

public interface IExpenseRepository
{
    void Add(ExpenseEntity expense);
}