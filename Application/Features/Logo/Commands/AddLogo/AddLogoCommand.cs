using Application.Models;
using MediatR;


namespace Application.Features.Logo.Commands.AddLogo
{
    public class AddLogoCommand : IRequest<ApiResponse>
    {
        public string? Base64 { get; set; }
        public string? Text { get; set; }
        public string? AltText { get; set; }
        public string? Path { get; set; }
    }
}
