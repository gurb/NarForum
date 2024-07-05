using Application.Features.BlogComment.Queries.GetBlogComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComment.Queries.GetBlogCommentsWithPagination
{
    public class BlogCommentsPaginationDTO
    {
        public List<BlogCommentDTO>? BlogComments { get; set; }
        public int TotalCount { get; set; }
    }
}
