using NarForumAdmin.Models;
using NarForumAdmin.Models.Logo;

namespace NarForumAdmin.Contracts
{
    public interface ILogoService
    {
        Task<LogoVM> GetLogo();
        Task<ApiResponseVM> AddLogo(AddLogoCommandVM command);
        Task<ApiResponseVM> UpdateLogo(UpdateLogoCommandVM command);
        Task<ApiResponseVM> RemoveLogo(RemoveLogoCommandVM command);

    }
}
