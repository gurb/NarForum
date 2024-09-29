using AdminUI.Models;
using AdminUI.Models.SmtpSettings;

namespace AdminUI.Contracts
{
    public interface ISmtpSettingsService
    {
        Task<SmtpSettingsVM> GetSmtpSettings();
        Task<ApiResponseVM> UpdateSmtpSettings(UpdateSmtpSettingsCommandVM command);
    }
}
