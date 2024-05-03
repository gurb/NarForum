using Application.Features.Category.Queries.GetCategories;
using MediatR;

namespace Application.Features.Category.Queries.GetParentCategories
{
    public class GetParentCategoriesQuery: IRequest<List<CategoryDTO>>
    {
        public string? CategoryName { get; set; }
    }
}
