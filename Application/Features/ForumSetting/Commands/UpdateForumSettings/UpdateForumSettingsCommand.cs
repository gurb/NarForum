using Application.Models;
using MediatR;

namespace Application.Features.ForumSetting.Commands.UpdateForumSettings
{
    public class UpdateForumSettingsCommand : IRequest<ApiResponse>
    {
        public string? ForumUrl { get; set; }

        public bool IsShowConsentCookie { get; set; }
    }
}
