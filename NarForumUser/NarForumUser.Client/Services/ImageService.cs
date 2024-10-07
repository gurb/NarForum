using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models;
using NarForumUser.Client.Models.Image;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;

namespace NarForumUser.Client.Services
{
    public class ImageService: BaseHttpService, IImageService
    {
        private readonly IMapper _mapper;
        public ImageService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<string>> GetImageUrlsFromGallery(string userId, string? dir)
        {
            var response =  await _client.GetImageUrlsFromGalleryAsync(userId, dir);

            return response.ToList();
        }

        public async Task<ApiResponseVM> UploadImageToServer(UploadImageRequestVM request)
        {
            UploadImageRequest req = _mapper.Map<UploadImageRequest>(request);

            var response = await _client.UploadImageFileAsync(req);

            return _mapper.Map<ApiResponseVM>(response);
        }


    }
}
