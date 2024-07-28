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
        public Guid PostId { get; set; }
        public string? UserName { get; set; }
        public Guid HeadingId { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
