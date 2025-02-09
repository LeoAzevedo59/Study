using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Expenses;
using Infra.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

internal class ExpensesRepository(ApiDbContext dbContext) : 
    IExpenseReadOnlyRepository,
    IExpenseWriteOnlyRepository,
    IExpenseUpdateOnlyRepository
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

    async Task<Expense?> IExpenseReadOnlyRepository.GetById(Guid expenseId)
    {
        var result = await dbContext.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == expenseId);

        return result;
    }
    
    async Task<Expense?> IExpenseUpdateOnlyRepository.GetById(Guid expenseId)
    {
        var result = await dbContext.Expenses
            .FirstOrDefaultAsync(expense => expense.Id == expenseId);

        return result;
    }

    public async Task<bool> Delete(Guid expenseId)
    {
     var expense = await dbContext.Expenses
         .FirstOrDefaultAsync(expanse => expanse.Id == expenseId);
        
     if(expense is null) return false;
     
     dbContext.Expenses.Remove(expense);
        
     return true;
    }

    public void Update(Expense expense)
    {
         dbContext.Update<Expense>(expense);
    }
}