using MediatR;

namespace Application.Features.Post.Commands.RemovePost
{
    
    public class RemovePostCommand : IRequest<int>
    {
        public int? PostId { get; set; }
    }
}
