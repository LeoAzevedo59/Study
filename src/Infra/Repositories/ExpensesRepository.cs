using Domain.Entities;
using Domain.Repositories.Expenses;
using Infra.DataAccess;

namespace Infra.Repositories;

internal class ExpensesRepository : IExpenseRepository
{
    public void Add(Expense expense)
    {
        var dbContext = new ApiDbContext();
        
        dbContext.Expenses.Add(expense);
        dbContext.SaveChanges();
    }
}