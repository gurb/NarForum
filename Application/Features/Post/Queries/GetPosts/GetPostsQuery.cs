using MediatR;

namespace Application.Features.Post.Queries.GetAllPosts
{
    public class GetPostsQuery: IRequest<List<PostDTO>>
    {
        public Guid HeadingId { get; set; }
    }
}
