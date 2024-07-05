

using Application.Models;
using MediatR;

namespace Application.Features.BlogPost.Commands.RemoveBlogPost;

public class RemoveBlogPostCommand: IRequest<ApiResponse>
{
    public int Id { get; set; } 
}
