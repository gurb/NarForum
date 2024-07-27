using Application.Features.Post.Queries.GetAllPosts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Post.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationQuery : IRequest<PostsPaginationDTO>
    {
        public string? PostId { get; set; }
        public string? UserName { get; set; }
        public string? HeadingId { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
