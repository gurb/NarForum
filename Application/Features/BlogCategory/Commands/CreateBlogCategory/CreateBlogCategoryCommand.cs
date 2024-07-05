using Application.Models;
using MediatR;

namespace Application.Features.BlogCategory.Commands.CreateBlogCategory;

public class CreateBlogCategoryCommand : IRequest<ApiResponse>
{
    public string Name { get; set; } = string.Empty;
}
