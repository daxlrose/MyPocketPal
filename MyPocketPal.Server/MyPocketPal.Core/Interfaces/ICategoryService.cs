using MyPocketPal.Core.Dtos.Categories;
using MyPocketPal.Data.Models;

namespace MyPocketPal.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<CreatedCategoryWithIdDto> AddCategoryAsync(CreateCategoryDto categoryDto);
        Task<SimpleCategoryDto> GetCategoryByIdAsync(int id);
        Task<IEnumerable<SimpleCategoryDto>> GetCategoriesAsync();
    }
}
