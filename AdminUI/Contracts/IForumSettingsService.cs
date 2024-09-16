using AdminUI.Models;
using AdminUI.Models.ForumSettings;
using AdminUI.Models.Logo;

namespace AdminUI.Contracts
{
    public interface IForumSettingsService
    {
        Task<ForumSettingsVM> GetForumSettings();
        Task<ApiResponseVM> UpdateForumSettings(UpdateForumSettingsCommandVM command);
    }
}
