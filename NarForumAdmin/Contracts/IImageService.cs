using NarForumAdmin.Models;
using NarForumAdmin.Models.Image;

namespace NarForumAdmin.Contracts
{
    public interface IImageService
    {
        public Task<ApiResponseVM> UploadImageToServer(UploadImageRequestVM request);
        public Task<List<string>> GetImageUrlsFromGallery(string userId, string? dir);
    }
}
