using Microsoft.EntityFrameworkCore;
using MyPocketPal.Data.Data;
using MyPocketPal.Data.Models;
using MyPocketPal.Data.Repositories.Interfaces;

namespace MyPocketPal.Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly MyPocketPalDbContext _context;

        public ExpenseRepository(MyPocketPalDbContext context)
        {
            _context = context;
        }

        public async Task<Expense> GetExpenseAsync(int id)
        {
            return await _context.Expenses
                .Include(e => e.Category)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {
            return await _context.Expenses
                .Include(e => e.Category)
                .ToListAsync();
        }

        public async Task<bool> ExpenseExistsAsync(int id)
        {
            return await _context.Expenses.AnyAsync(e => e.Id == id);
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }
    }
}
