using Application.Models;
using Application.Models.Enums;
using Application.Models.Persistence.Image;
using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Persistence
{
    public interface IImageService
    {
        Task<ApiResponse> UploadImageToServer(UploadImageRequest request);
        List<string> GetImageUrlsFromGallery(string userId, string? dir);
    }
}
