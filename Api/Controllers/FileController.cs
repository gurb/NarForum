using Application.Contracts.Persistence;
using Application.Models;
using Application.Models.Persistence.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageService _imageService;
        public FileController(IWebHostEnvironment webHostEnvironment, IImageService imageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
        }

        /// <summary>
        /// Uploads image file.
        /// </summary>
        /// <param name="request">The request containing </param>
        /// <returns>The uploading image file result as ApiResponse</returns>
        [HttpPost("UploadImageFile")]
        public async Task<ApiResponse> UploadImageFile([FromBody]UploadImageRequest request)
        {
            var dir = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads", "Images");
            request.Dir = dir;
            var response = await _imageService.UploadImageToServer(request);

            return response;
        }

        /// <summary>
        /// Gets image urls from gallery by userId.
        /// </summary>
        /// <param name="userId">UserId(string)</param>
        /// <param name="dir">Folder dir path</param>
        /// <returns>The getting image urls result as the list of string.</returns>
        [HttpPost("GetImageUrlsFromGallery")]
        public async Task<List<string>> GetImageUrlsFromGallery(string userId, string? dir)
        {
            if(dir == null)
            {
                dir = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads", "Images");
            }
            var response =  _imageService.GetImageUrlsFromGallery(userId, dir);

            return response;
        }

        /// <summary>
        /// Gets user profile image file.
        /// </summary>
        /// <param name="userId">UserId(string)</param>
        /// <returns>Gets user profile image file result as IActionResult</returns>
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Client, NoStore = false)]
        [HttpGet("images/user-profile/{userId}")]
        [AllowAnonymous]
        [EnableCors("AllowAllOriginsForImages")]
        public IActionResult GetUserProfileImageFile(string userId)
        {
            var dir = Path.Combine(_webHostEnvironment.ContentRootPath, $"Uploads/Images/Users/{userId}/user-profile");

            if (!Directory.Exists(dir))
            {
                return NotFound();    
            }
            var files = Directory.GetFiles(dir);

            if (files.Length == 0)
            {
                return NotFound("No files found in the directory.");
            }

            var fileName = Path.GetFileName(files[0]);
            var filePath = Path.Combine(dir, fileName);

            var imageFileStream = System.IO.File.OpenRead(filePath);
            return File(imageFileStream, "image/jpeg");
        }

        /// <summary>
        /// Gets user gallery image file.
        /// </summary>
        /// <param name="userId">UserId(string)</param>
        /// <param name="filename">Filename(string)</param>
        /// <returns>The gettingg user gallery image file result as IActionResult</returns>
        [HttpGet("images/user-gallery/{userId}/{filename}")]
        [AllowAnonymous]
        [EnableCors("AllowAllOriginsForImages")]
        public IActionResult GetUserGalleryImageFile(string userId, string filename)
        {
            var filepath = Path.Combine(_webHostEnvironment.ContentRootPath, $"Uploads/Images/Users/{userId}/user-gallery/{filename}");

            if (!System.IO.File.Exists(filepath))
            {
                return NotFound();
            }

            var imageFileStream = System.IO.File.OpenRead(filepath);
            return File(imageFileStream, "image/jpeg");
        }

        /// <summary>
        /// Gets logo file.
        /// </summary>
        /// <returns>The getting logo file result as IActionResult</returns>
        [HttpGet("images/logo/")]
        [AllowAnonymous]
        [EnableCors("AllowAllOriginsForImages")]
        public IActionResult GetLogoFile()
        {
            var dir = Path.Combine(_webHostEnvironment.ContentRootPath, $"Uploads/Images/Logo/");

            if (!Directory.Exists(dir))
            {
                return NotFound();
            }
            var files = Directory.GetFiles(dir);

            if (files.Length == 0)
            {
                return NotFound("No files found in the directory.");
            }

            var fileName = Path.GetFileName(files[0]);
            var filePath = Path.Combine(dir, fileName);

            var imageFileStream = System.IO.File.OpenRead(filePath);
            return File(imageFileStream, "image/png");
        }
    }
}
