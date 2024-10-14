using Application.Models.Enums;
using MediatR;

namespace Application.Features.Post.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationQuery : IRequest<PostsPaginationDTO>
    {
        public Guid? PostId { get; set; }
        public string? UserName { get; set; }
        public bool IsWithHeading { get; set; }
        public Guid? HeadingId { get; set; }
        public string? SearchUsername { get; set; }
        public string? SearchContent { get; set; }
        public bool IsAdminPanel { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortType SortType { get; set; } = SortType.OLDEST;
    }
}
