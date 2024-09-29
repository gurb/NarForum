using BlazorUI.Models;
using BlazorUI.Models.SmtpSettings;

namespace BlazorUI.Contracts
{
    public interface ISmtpSettingsService
    {
        Task<SmtpSettingsVM> GetSmtpSettings();
    }
}
