using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Post.Queries.GetAllPosts
{
    public class GetPostsQuery: IRequest<List<PostDTO>>
    {
        public int? HeadingId { get; set; }
    }
}
