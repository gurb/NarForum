using Application.Models;
using MediatR;

namespace Application.Features.Logo.Commands.UpdateLogo
{
    public class UpdateLogoCommand : IRequest<ApiResponse>
    {
        public string? Base64 { get; set; }
        public string? Text { get; set; }
        public string? AltText { get; set; }
        public string? Path { get; set; }
    }
}
