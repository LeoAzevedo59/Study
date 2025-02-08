using ExpenseEntity = Domain.Entities.Expense;
namespace Domain.Repositories;

public interface IExpenseRepository
{
    Task Add(ExpenseEntity expense);
}