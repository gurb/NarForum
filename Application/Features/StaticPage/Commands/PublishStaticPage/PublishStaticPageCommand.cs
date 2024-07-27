using Application.Models;
using MediatR;

namespace Application.Features.StaticPage.Commands.PublishStaticPage
{
    public class PublishStaticPageCommand: IRequest<ApiResponse>
    {
        public string? Id { get; set; }
    }
}
