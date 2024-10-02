using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.Image;

namespace GurbForumUser.Client.Contracts
{
    public interface IImageService
    {
        public Task<ApiResponseVM> UploadImageToServer(UploadImageRequestVM request);
        public Task<List<string>> GetImageUrlsFromGallery(string userId, string? dir);
    }
}
