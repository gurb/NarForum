using Application.Contracts.Persistence;
using Application.Models;
using Application.Models.Persistence.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageService _imageService;
        public FileController(IWebHostEnvironment webHostEnvironment, IImageService imageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<ApiResponse> UploadImageFile(UploadImageRequest request)
        {
            var dir = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads", "Images");
            request.Dir = dir;
            var response = await _imageService.UploadImageToServer(request);

            return response;
        }

    }
}
