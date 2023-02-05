using MyPocketPal.Data.Models;

namespace MyPocketPal.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
    }
}
