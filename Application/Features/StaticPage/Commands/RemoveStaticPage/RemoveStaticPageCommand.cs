using Application.Models;
using MediatR;

namespace Application.Features.StaticPage.Commands.RemoveStaticPage;

public class RemoveStaticPageCommand: IRequest<ApiResponse>
{
    public int Id { get; set; }
}
