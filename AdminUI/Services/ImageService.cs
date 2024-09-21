using AdminUI.Contracts;
using AdminUI.Models;
using AdminUI.Models.Image;
using AdminUI.Services.Base;
using AdminUI.Services.Common;
using AutoMapper;

namespace AdminUI.Services
{
    public class ImageService : BaseHttpService, IImageService
    {
        private readonly IMapper _mapper;
        public ImageService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> UploadImageToServer(UploadImageRequestVM request)
        {
            UploadImageRequest req = _mapper.Map<UploadImageRequest>(request);

            var response = await _client.UploadImageFileAsync(req);

            return _mapper.Map<ApiResponseVM>(response);
        }
    }
}
