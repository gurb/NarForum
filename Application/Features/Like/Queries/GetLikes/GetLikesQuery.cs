using MediatR;

namespace Application.Features.Like.Queries.GetLikes
{
    public class GetLikesQuery : IRequest<List<LikeDTO>>
    {
        public Guid PostId { get; set; }
        public Guid HeadingId { get; set; }
        public string? UserName { get; set; }
    }
}
