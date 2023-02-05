using MyPocketPal.Data.Models;

namespace MyPocketPal.Core.Interfaces
{
    public interface IExpenseService
    {
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense> GetExpenseByIdAsync(int id);
        Task<List<Expense>> GetExpensesAsync();
        Task<Expense> UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(Expense expense);
    }
}
