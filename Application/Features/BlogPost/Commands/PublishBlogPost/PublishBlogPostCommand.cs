using Application.Models;
using MediatR;

namespace Application.Features.BlogPost.Commands.PublishBlogPost
{
    public class PublishBlogPostCommand: IRequest<ApiResponse>
    {
        public Guid Id { get; set; }
    }
}
