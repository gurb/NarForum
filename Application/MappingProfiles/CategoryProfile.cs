using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Queries.GetCategories;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        }
    }
}
