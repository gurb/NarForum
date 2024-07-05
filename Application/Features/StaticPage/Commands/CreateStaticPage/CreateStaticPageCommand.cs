using Application.Models;
using MediatR;

namespace Application.Features.StaticPage.Commands.CreateStaticPage;

public class CreateStaticPageCommand: IRequest<ApiResponse>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}
