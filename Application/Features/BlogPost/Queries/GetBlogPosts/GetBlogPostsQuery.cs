﻿using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPosts;

public class GetBlogPostsQuery : IRequest<List<BlogPostDTO>>
{
    public int? BlogCategoryId { get; set; }
}