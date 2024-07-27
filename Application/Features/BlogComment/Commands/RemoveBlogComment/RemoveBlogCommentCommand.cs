using Application.Models;
using MediatR;


namespace Application.Features.BlogComment.Commands.RemoveBlogComment;

public class RemoveBlogCommentCommand: IRequest<ApiResponse>
{
    public string? Id { get; set; }
}
