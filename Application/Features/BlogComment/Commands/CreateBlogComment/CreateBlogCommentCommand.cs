﻿using Application.Models;
using MediatR;

namespace Application.Features.BlogComment.Commands.CreateBlogComment;

public class CreateBlogCommentCommand: IRequest<ApiResponse>
{
    public int? BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
}
