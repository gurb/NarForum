using MediatR;

namespace Application.Features.Like.Queries.GetLikes
{
    public class GetLikesQuery : IRequest<List<LikeDTO>>
    {
        public int? PostId { get; set; }
        public int? HeadingId { get; set; }
        public string? UserName { get; set; }
    }
}
