using Domain.Entities;
using Domain.Repositories;
using Infra.DataAccess;

namespace Infra.Repositories;

internal class ExpensesRepository(ApiDbContext dbContext) : IExpenseRepository
{
    public async Task Add(Expense expense)
    {
        await dbContext.Expenses.AddAsync(expense);
    }
}