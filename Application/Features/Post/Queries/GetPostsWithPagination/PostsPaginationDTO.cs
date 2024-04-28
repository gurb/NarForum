using Application.Features.Post.Queries.GetAllPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Post.Queries.GetPostsWithPagination
{
    public class PostsPaginationDTO
    {
        public List<PostDTO>? Posts { get; set; }
        public int TotalCount { get; set; }
    }
}
