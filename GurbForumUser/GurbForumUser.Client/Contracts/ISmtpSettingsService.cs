using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.SmtpSettings;

namespace GurbForumUser.Client.Contracts
{
    public interface ISmtpSettingsService
    {
        Task<SmtpSettingsVM> GetSmtpSettings();
    }
}
