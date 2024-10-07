using NarForumAdmin.Models;
using NarForumAdmin.Models.ForumSettings;
using NarForumAdmin.Models.Logo;

namespace NarForumAdmin.Contracts
{
    public interface IForumSettingsService
    {
        Task<ForumSettingsVM> GetForumSettings();
        Task<ApiResponseVM> UpdateForumSettings(UpdateForumSettingsCommandVM command);
    }
}
