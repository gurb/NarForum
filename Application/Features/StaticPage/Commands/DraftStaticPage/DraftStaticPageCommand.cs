using Application.Models;
using MediatR;

namespace Application.Features.StaticPage.Commands.DraftStaticPage
{
    public class DraftStaticPageCommand: IRequest<ApiResponse>
    {
        public Guid Id { get; set; } = Guid.Empty;
    }

}
