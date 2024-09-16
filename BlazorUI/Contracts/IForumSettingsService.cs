using BlazorUI.Models.ForumSettings;

namespace BlazorUI.Contracts
{
    public interface IForumSettingsService
    {
        Task<ForumSettingsVM> GetForumSettings();
    }
}
