using MediatR;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostCommand: IRequest<Guid>
    {
        public string Content { get; set; } = string.Empty;
        public Guid HeadingId { get; set; }
        public List<Guid>? QuotePostIds { get; set; }
    }
}
