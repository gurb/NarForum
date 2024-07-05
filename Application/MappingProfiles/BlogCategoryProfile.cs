using Application.Features.BlogCategory.Commands.CreateBlogCategory;
using Application.Features.BlogCategory.Queries.GetBlogCategories;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class BlogCategoryProfile: Profile   
    {
        public BlogCategoryProfile()
        {
            CreateMap<BlogCategoryDTO, BlogCategory>().ReverseMap();
            CreateMap<CreateBlogCategoryCommand, BlogCategory>().ReverseMap();
        }
    }
}
