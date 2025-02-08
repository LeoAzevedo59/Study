using Domain.Entities;
using Domain.Repositories.Expenses;
using Infra.DataAccess;

namespace Infra.Repositories;

internal class ExpensesRepository(ApiDbContext dbContext) : IExpenseRepository
{
    public void Add(Expense expense)
    {
        dbContext.Expenses.Add(expense);
        dbContext.SaveChanges();
    }
}