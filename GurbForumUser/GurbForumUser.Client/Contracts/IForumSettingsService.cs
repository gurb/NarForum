using GurbForumUser.Client.Models.ForumSettings;

namespace GurbForumUser.Client.Contracts
{
    public interface IForumSettingsService
    {
        Task<ForumSettingsVM> GetForumSettings();
    }
}
