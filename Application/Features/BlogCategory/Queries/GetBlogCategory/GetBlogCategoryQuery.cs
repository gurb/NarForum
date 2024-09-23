using Application.Features.BlogCategory.Queries.GetBlogCategories;
using MediatR;

namespace Application.Features.BlogCategory.Queries.GetBlogCategory
{
    public class GetBlogCategoryQuery : IRequest<BlogCategoryDTO>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
