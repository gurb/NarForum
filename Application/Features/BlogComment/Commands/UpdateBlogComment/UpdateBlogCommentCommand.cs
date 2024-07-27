﻿using Application.Models;
using MediatR;

namespace Application.Features.BlogComment.Commands.UpdateBlogComment;

public class UpdateBlogCommentCommand: IRequest<ApiResponse>
{
    public string? Id { get; set; }
    public string Content { get; set; } = string.Empty;
}
