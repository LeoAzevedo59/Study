using Domain.Entities;
namespace Domain.Repositories.Expenses;

public interface IExpenseRepository
{
    void AddExpense(Expense expense);
}