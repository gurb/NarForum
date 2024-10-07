using NarForumAdmin.Models;
using NarForumAdmin.Models.SmtpSettings;

namespace NarForumAdmin.Contracts
{
    public interface ISmtpSettingsService
    {
        Task<SmtpSettingsVM> GetSmtpSettings();
        Task<ApiResponseVM> UpdateSmtpSettings(UpdateSmtpSettingsCommandVM command);
    }
}
