using NarForumUser.Client.Models.Logo;

namespace NarForumUser.Client.Contracts
{
    public interface ILogoService
    {
        Task<LogoVM> GetLogo();
    }
}
