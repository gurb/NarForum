using NarForumUser.Client.Models.ForumSettings;

namespace NarForumUser.Client.Contracts
{
    public interface IForumSettingsService
    {
        Task<ForumSettingsVM> GetForumSettings();
    }
}
