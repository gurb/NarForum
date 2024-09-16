using BlazorUI.Models.Logo;

namespace BlazorUI.Contracts
{
    public interface ILogoService
    {
        Task<LogoVM> GetLogo();
    }
}
