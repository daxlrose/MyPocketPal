using AutoMapper;
using MyPocketPal.Core.Dtos.Expenses;
using MyPocketPal.Data.Models;

namespace MyPocketPal.Api.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseWithCategoryNameDto>()
            .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dto => dto.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dto => dto.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dto => dto.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateExpenseDto, Expense>();

            CreateMap<Expense, CreatedExpenseWithCategoryNameAndIdDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dto => dto.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dto => dto.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dto => dto.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<UpdateExpenseDto, Expense>();
        }
    }
}
