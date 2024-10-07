using NarForumUser.Client.Models;
using NarForumUser.Client.Models.SmtpSettings;

namespace NarForumUser.Client.Contracts
{
    public interface ISmtpSettingsService
    {
        Task<SmtpSettingsVM> GetSmtpSettings();
    }
}
