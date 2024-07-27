using Application.Models;
using MediatR;

namespace Application.Features.BlogPost.Commands.UpdateBlogPost
{
    public class UpdateBlogPostCommand: IRequest<ApiResponse>
    {
        public string? Id { get; set; }
        public string? BlogCategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
