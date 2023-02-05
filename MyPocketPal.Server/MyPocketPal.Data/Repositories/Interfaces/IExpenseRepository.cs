using MyPocketPal.Data.Models;

namespace MyPocketPal.Data.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense> GetExpenseAsync(int id);
        Task<List<Expense>> GetExpensesAsync();
        Task<bool> ExpenseExistsAsync(int id);
        Task<Expense> AddExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int id);
    }
}
