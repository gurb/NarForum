using Application.Models;
using MediatR;

namespace Application.Features.StaticPage.Commands.PublishStaticPage
{
    public class PublishStaticPageCommand: IRequest<ApiResponse>
    {
        public Guid Id { get; set; } = Guid.Empty;
	}
}
