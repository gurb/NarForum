using MediatR;

namespace Application.Features.Post.Commands.RemovePost
{
    public class RemovePostCommand : IRequest<Guid>
    {
        public Guid PostId { get; set; }
    }
}
