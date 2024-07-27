using Application.Models;
using MediatR;

namespace Application.Features.StaticPage.Commands.DraftStaticPage
{
    public class DraftStaticPageCommand: IRequest<ApiResponse>
    {
        public string? Id { get; set; }
    }

}
