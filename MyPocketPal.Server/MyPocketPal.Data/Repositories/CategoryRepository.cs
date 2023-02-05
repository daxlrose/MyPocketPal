using Microsoft.EntityFrameworkCore;
using MyPocketPal.Data.Data;
using MyPocketPal.Data.Models;
using MyPocketPal.Data.Repositories.Interfaces;

namespace MyPocketPal.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyPocketPalDbContext _context;

        public CategoryRepository(MyPocketPalDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
