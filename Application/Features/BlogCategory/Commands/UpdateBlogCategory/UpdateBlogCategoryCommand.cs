using Application.Models;
using MediatR;

namespace Application.Features.BlogCategory.Commands.UpdateBlogCategory;

public class UpdateBlogCategoryCommand: IRequest<ApiResponse>
{
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
