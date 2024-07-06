using Application.Models;
using MediatR;

namespace Application.Features.BlogPost.Commands.PublishBlogPost
{
    public class PublishBlogPostCommand: IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
