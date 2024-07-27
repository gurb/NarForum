﻿using MediatR;


namespace Application.Features.BlogPost.Queries.GetBlogPostsWithPagination;

public class GetBlogPostsWithPaginationQuery: IRequest<BlogPostsPaginationDTO>
{
    public string? BlogCategoryId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
