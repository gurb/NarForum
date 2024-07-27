using Application.Models;
using MediatR;

namespace Application.Features.BlogPost.Commands.CreateBlogPost;

public class CreateBlogPostCommand: IRequest<ApiResponse>
{
    public string? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Url { get; set; } = string.Empty;
}
