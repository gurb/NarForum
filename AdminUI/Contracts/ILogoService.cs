using AdminUI.Models;
using AdminUI.Models.Logo;

namespace AdminUI.Contracts
{
    public interface ILogoService
    {
        Task<LogoVM> GetLogo();
        Task<ApiResponseVM> AddLogo(AddLogoCommandVM command);
        Task<ApiResponseVM> UpdateLogo(UpdateLogoCommandVM command);
        Task<ApiResponseVM> RemoveLogo(RemoveLogoCommandVM command);

    }
}
