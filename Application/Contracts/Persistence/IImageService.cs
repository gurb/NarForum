using Application.Models;
using Application.Models.Persistence.Image;

namespace Application.Contracts.Persistence
{
    public interface IImageService
    {
        Task<ApiResponse> UploadImageToServer(UploadImageRequest request);
        List<string> GetImageUrlsFromGallery(string userId, string? dir);
    }
}
