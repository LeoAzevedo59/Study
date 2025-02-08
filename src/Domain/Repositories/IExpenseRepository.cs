using Domain.Entities;

namespace Domain.Repositories;

public interface IExpenseRepository
{
    Task Add(Expense expense);
    Task<List<Expense>> Get();
    Task<Expense?> GetById(Guid expenseId);
}