using BlazorUI.Models;
using BlazorUI.Models.Image;

namespace BlazorUI.Contracts
{
    public interface IImageService
    {
        public Task<ApiResponseVM> UploadImageToServer(UploadImageRequestVM request);
    }
}
