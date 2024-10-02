using GurbForumUser.Client.Models.Logo;

namespace GurbForumUser.Client.Contracts
{
    public interface ILogoService
    {
        Task<LogoVM> GetLogo();
    }
}
