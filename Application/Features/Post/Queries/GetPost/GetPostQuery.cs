using Application.Features.Post.Queries.GetAllPosts;
using MediatR;

namespace Application.Features.Post.Queries.GetPost
{
    public class GetPostQuery: IRequest<PostDTO>
    {
        public Guid Id { get; set; }
    }
}
