using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using AutoMapper;
using MyPocketPal.Core.Dtos.Categories;
using MyPocketPal.Core.Interfaces;
using MyPocketPal.Data.Models;
using MyPocketPal.Data.Repositories.Interfaces;

namespace MyPocketPal.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryWithIdDto> AddCategoryAsync(CreateCategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    throw new ArgumentNullException("Category cannot be null.");
                }

                var category = _mapper.Map<Category>(categoryDto);
                var result = await _categoryRepository.AddCategoryAsync(category);
                return _mapper.Map<CreatedCategoryWithIdDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding category", ex);
            }
        }

        public async Task<SimpleCategoryDto> GetCategoryByIdAsync(int id)
        {
            try
            {
                var result = await _categoryRepository.GetCategoryAsync(id);
                if (result == null)
                {
                    throw new ArgumentException("Category not found.");
                }

                return _mapper.Map<SimpleCategoryDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving category", ex);
            }
        }

        public async Task<IEnumerable<SimpleCategoryDto>> GetCategoriesAsync()
        {
            try
            {
                var result = await _categoryRepository.GetCategoriesAsync();
                return _mapper.Map<IEnumerable<SimpleCategoryDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving categories", ex);
            }
        }
    }
}
