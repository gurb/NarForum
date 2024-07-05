using MediatR;

namespace Application.Features.BlogCategory.Queries.GetBlogCategories;

public class GetBlogCategoriesQuery: IRequest<List<BlogCategoryDTO>>
{
    public string? SearchText { get; set; }
}
