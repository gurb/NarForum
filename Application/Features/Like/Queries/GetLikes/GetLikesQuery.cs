using MediatR;

namespace Application.Features.Like.Queries.GetLikes
{
    public class GetLikesQuery : IRequest<List<LikeDTO>>
    {
        public string? PostId { get; set; }
        public string? HeadingId { get; set; }
        public string? UserName { get; set; }
    }
}
