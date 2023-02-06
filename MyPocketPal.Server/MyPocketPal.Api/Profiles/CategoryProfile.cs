using AutoMapper;
using MyPocketPal.Core.Dtos.Categories;
using MyPocketPal.Data.Models;

namespace MyPocketPal.Api.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CreatedCategoryWithIdDto>().ReverseMap();
            CreateMap<Category, SimpleCategoryDto>().ReverseMap();
        }
    }
}
