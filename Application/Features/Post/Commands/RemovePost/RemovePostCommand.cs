using MediatR;

namespace Application.Features.Post.Commands.RemovePost
{
    public class RemovePostCommand : IRequest<string>
    {
        public string? PostId { get; set; }
    }
}
