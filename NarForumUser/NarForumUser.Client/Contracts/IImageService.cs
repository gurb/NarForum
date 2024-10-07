using NarForumUser.Client.Models;
using NarForumUser.Client.Models.Image;

namespace NarForumUser.Client.Contracts
{
    public interface IImageService
    {
        public Task<ApiResponseVM> UploadImageToServer(UploadImageRequestVM request);
        public Task<List<string>> GetImageUrlsFromGallery(string userId, string? dir);
    }
}
