using MediatR;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostCommand: IRequest<int>
    {
        public string Content { get; set; } = string.Empty;
        public int HeadingId { get; set; }
    }
}
