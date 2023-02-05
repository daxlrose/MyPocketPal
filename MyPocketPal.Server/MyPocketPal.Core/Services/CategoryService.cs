using MyPocketPal.Core.Interfaces;
using MyPocketPal.Data.Models;
using MyPocketPal.Data.Repositories.Interfaces;

namespace MyPocketPal.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException("Category cannot be null.");
                }

                var result = await _categoryRepository.AddCategoryAsync(category);
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception.
                throw ex;
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            try
            {
                var result = await _categoryRepository.GetCategoryAsync(id);
                if (result == null)
                {
                    throw new ArgumentException("Category not found.");
                }

                return result;
            }
            catch (Exception ex)
            {
                // Log the exception.
                throw ex;
            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var result = await _categoryRepository.GetCategoriesAsync();
                return result;
            }
            catch (Exception ex)
            {
                // Log the exception.
                throw ex;
            }
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException("Category cannot be null.");
                }

                var categoryExists = await _categoryRepository.CategoryExistsAsync(category.Id);
                if (!categoryExists)
                {
                    throw new ArgumentException("Category not found.");
                }

                await _categoryRepository.UpdateCategoryAsync(category);
                return category;
            }
            catch (Exception ex)
            {
                // Log the exception.
                throw ex;
            }
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException("Category cannot be null.");
                }

                if (!await _categoryRepository.CategoryExistsAsync(category.Id))
                {
                    throw new ArgumentException("Category not found.");
                }

                await _categoryRepository.DeleteCategoryAsync(category.Id);
            }
            catch (Exception ex)
            {
                // Log the exception.
                throw ex;
            }
        }
    }
}
