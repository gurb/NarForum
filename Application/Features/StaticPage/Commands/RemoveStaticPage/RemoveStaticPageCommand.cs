using Application.Models;
using MediatR;

namespace Application.Features.StaticPage.Commands.RemoveStaticPage;

public class RemoveStaticPageCommand: IRequest<ApiResponse>
{
    public string? Id { get; set; }
}
