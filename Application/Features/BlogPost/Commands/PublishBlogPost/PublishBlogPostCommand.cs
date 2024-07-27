using Application.Models;
using MediatR;

namespace Application.Features.BlogPost.Commands.PublishBlogPost
{
    public class PublishBlogPostCommand: IRequest<ApiResponse>
    {
        public string? Id { get; set; }
    }
}
