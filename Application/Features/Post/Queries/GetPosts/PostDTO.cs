using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Post.Queries.GetAllPosts
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? HeadingId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string? CategoryName { get; set; }
        public string? HeadingTitle { get; set; }
    }
}
