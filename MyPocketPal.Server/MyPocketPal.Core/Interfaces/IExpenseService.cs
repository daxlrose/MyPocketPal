using MyPocketPal.Core.Dtos.Expenses;
using MyPocketPal.Data.Models;

namespace MyPocketPal.Core.Interfaces
{
    public interface IExpenseService
    {
        Task<CreatedExpenseWithCategoryNameAndIdDto> AddExpenseAsync(CreateExpenseDto expenseDto);
        Task<ExpenseWithCategoryNameDto> GetExpenseByIdAsync(int id);
        Task<IEnumerable<ExpenseWithCategoryNameDto>> GetExpensesAsync();
        Task<Expense> UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(Expense expense);
    }
}
