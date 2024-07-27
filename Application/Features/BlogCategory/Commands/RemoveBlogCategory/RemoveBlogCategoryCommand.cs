using Application.Models;
using MediatR;

namespace Application.Features.BlogCategory.Commands.RemoveBlogCategory;

public class RemoveBlogCategoryCommand: IRequest<ApiResponse>
{
    public string? Id { get; set; }
}
