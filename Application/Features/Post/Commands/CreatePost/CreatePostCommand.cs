using MediatR;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostCommand: IRequest<string>
    {
        public string Content { get; set; } = string.Empty;
        public string? HeadingId { get; set; }
        public List<string?>? QuotePostIds { get; set; }
    }
}
