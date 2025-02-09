using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Expenses;
using Infra.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

internal class ExpensesRepository(ApiDbContext dbContext) : IExpenseReadOnlyRepository, IExpenseWriteOnlyRepository
{
    public async Task Add(Expense expense)
    {
        await dbContext.Expenses.AddAsync(expense);
    }
    
    public async Task<List<Expense>> Get()
    {
        var result = await dbContext.Expenses
            .AsNoTracking().ToListAsync();
        
        return result;
    }

    public async Task<Expense?> GetById(Guid expenseId)
    {
        var result = await dbContext.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == expenseId);

        return result;
    }
}