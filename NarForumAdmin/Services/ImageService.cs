using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.Image;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
{
    public class ImageService : BaseHttpService, IImageService
    {
        private readonly IMapper _mapper;
        public ImageService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<string>> GetImageUrlsFromGallery(string userId, string? dir)
        {
            
            try
            {
                var response = await _client.GetImageUrlsFromGalleryAsync(userId, dir);

                return response.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UploadImageToServer(UploadImageRequestVM request)
        {
            try
            {
                UploadImageRequest req = _mapper.Map<UploadImageRequest>(request);

                var response = await _client.UploadImageFileAsync(req);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
