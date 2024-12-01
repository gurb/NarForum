using NarForumAdmin.Models;

namespace NarForumAdmin.Contracts
{
    public interface ILanguageService
    {
        public Task<ApiResponseVM> ChangeLanguage(string lang, string jsonStr);
    }
}
