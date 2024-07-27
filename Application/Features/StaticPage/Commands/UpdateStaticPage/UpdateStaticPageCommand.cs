using Application.Models;
using MediatR;

namespace Application.Features.StaticPage.Commands.UpdateStaticPage;

public class UpdateStaticPageCommand : IRequest<ApiResponse>
{
    public string? Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}
