using Domain.Entities;

namespace Domain.Repositories.Expenses
{
    public interface IExpenseWriteOnlyRepository
    {
        Task Add(Expense expense);

        /// <summary>
        ///     This function returns TRUE if the deletion was successful otherwise returns
        ///     FALSE
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid expenseId);
    }
}
