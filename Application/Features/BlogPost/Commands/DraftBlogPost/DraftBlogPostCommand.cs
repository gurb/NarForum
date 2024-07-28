using Application.Models;
using MediatR;

namespace Application.Features.BlogPost.Commands.DraftBlogPost
{
    public class DraftBlogPostCommand: IRequest<ApiResponse>
    {
        public Guid Id { get; set; }
    }
}
