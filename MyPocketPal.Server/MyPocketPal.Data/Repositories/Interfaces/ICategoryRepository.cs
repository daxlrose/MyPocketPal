using MyPocketPal.Data.Models;

namespace MyPocketPal.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryAsync(int id);
        Task<List<Category>> GetCategoriesAsync();
        Task<bool> CategoryExistsAsync(int id);
        Task<Category> AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
