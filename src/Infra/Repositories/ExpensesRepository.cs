using Domain.Entities;
using Domain.Repositories.Expenses;
using Infra.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    internal class ExpensesRepository(ApiDbContext dbContext) :
        IExpenseReadOnlyRepository,
        IExpenseWriteOnlyRepository,
        IExpenseUpdateOnlyRepository
    {
        public async Task<List<Expense>> Get()
        {
            List<Expense> result = await dbContext.Expenses
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        async Task<Expense?> IExpenseReadOnlyRepository.GetById(Guid expenseId)
        {
            Expense? result = await dbContext.Expenses
                .AsNoTracking()
                .FirstOrDefaultAsync(expense => expense.Id == expenseId);

            return result;
        }

        async Task<Expense?> IExpenseUpdateOnlyRepository.GetById(
            Guid expenseId)
        {
            Expense? result = await dbContext.Expenses.FindAsync(expenseId);
            return result;
        }

        public void Update(Expense expense)
        {
            dbContext.Update(expense);
        }

        public async Task Add(Expense expense)
        {
            await dbContext.Expenses.AddAsync(expense);
        }

        public async Task<bool> Delete(Guid expenseId)
        {
            Expense? expense = await dbContext.Expenses.FindAsync(expenseId);

            if (expense is null)
            {
                return false;
            }

            dbContext.Expenses.Remove(expense);

            return true;
        }
    }
}
