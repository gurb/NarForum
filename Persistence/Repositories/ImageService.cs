using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Models;
using Application.Models.Enums;
using Application.Models.Persistence.Image;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class ImageService : IImageService
    {
        private readonly string[] _allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
        // max 5mb
        private readonly long _maxFileSize = 5 * 1024 * 1024;

        protected readonly ForumDbContext _context;

        public ImageService(ForumDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ApiResponse> UploadImageToServer(UploadImageRequest request)
        {
            ApiResponse response;

            response = FirstControlOfImage(request);

            if (!response.IsSuccess)
                return response;

            if (request.Type == UploadImageType.UserProfile)
            {
                if (request.UserId == null)
                {
                    response.IsSuccess = false;
                    response.Message = "UserID is null";

                    return response;
                }

                response = await UploadImageAsUserProfile(request);
            }
            else if(request.Type == UploadImageType.Gallery)
            {
                if (request.UserId == null)
                {
                    response.IsSuccess = false;
                    response.Message = "UserID is null";

                    return response;
                }
                response = await UploadImageToUserGallery(request);
            }
            else if (request.Type == UploadImageType.GeneralUse)
            {
                response = await UploadImageAsGeneralUse(request);
            }
            else if (request.Type == UploadImageType.Logo)
            {
                response = await UploadImageAsLogo(request);
            }
            else if (request.Type == UploadImageType.Favicon)
            {
                response = await UploadImageAsFavicon(request);
            }

            return response;
        }

        private ApiResponse FirstControlOfImage(UploadImageRequest request)
        {
            ApiResponse response = new ApiResponse();

            if(request.FilesBase64 != null && request.FilesBase64.Count > 0)
            {

            }
            else
            {
				if (request.Files == null || request.Files.Count == 0)
				{
					response.IsSuccess = false;
					response.Message = "Choose a file";
					return response;
				}

				foreach (var file in request.Files)
				{
					var extensionFile = Path.GetExtension(file.FileName).ToLower();
					if (!_allowedExtensions.Contains(extensionFile))
					{
						response.IsSuccess = false;
						response.Message = "Invalid file";
						return response;
					}

					if (file.Length > _maxFileSize)
					{
						response.IsSuccess = false;
						response.Message = "File size is too large.";
						return response;
					}
				}
			}


			if (request.Dir == null)
            {
                response.IsSuccess = false;
                response.Message = "Not found a DIR value";
                return response;
            }

            if (!Directory.Exists(request.Dir))
            {
                Directory.CreateDirectory(request.Dir);
            }


            return response;
        }
        private async Task<ApiResponse> UploadImageAsUserProfile(UploadImageRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                List<UploadFile> uploadFiles = new List<UploadFile>();

                //var user = await _userService.GetCurrentUser();

                foreach (var file in request.Files)
                {
                    bool isUpdate = false;

                    string trustedFileName = request.UserId.ToString();
                    string untrustedFileName = file.FileName;

                    var userDir = Path.Combine(request.Dir, "Users", request.UserId.ToString(), "user-profile");
                    if (!Directory.Exists(userDir))
                    {
                        Directory.CreateDirectory(userDir);
                    }

                    var pathFile = Path.Combine(userDir, trustedFileName);
                    if (File.Exists(pathFile))
                    {
                        File.Delete(pathFile);
                        isUpdate = true;
                    }

                    await using FileStream fs = new(pathFile, FileMode.Create);
                    await file.CopyToAsync(fs);

                    if (isUpdate)
                    {
                        var updateUploadFile = await _context.UploadFiles.FirstOrDefaultAsync(x => x.StoredFileName == trustedFileName);

                        if (updateUploadFile != null)
                        {
                            updateUploadFile.StoredFileName = trustedFileName;
                            updateUploadFile.FileName = untrustedFileName;
                            updateUploadFile.UserName = null;
                            updateUploadFile.UploadDate = DateTime.UtcNow;
                            _context.UploadFiles.Update(updateUploadFile);
                        }
                    }
                    else
                    {
                        var uploadFile = new UploadFile();

                        uploadFile.StoredFileName = trustedFileName;
                        uploadFile.FileName = untrustedFileName;
                        uploadFile.UserName = null;
                        uploadFile.UploadDate = DateTime.UtcNow;
                        uploadFiles.Add(uploadFile);
                        _context.UploadFiles.Add(uploadFile);
                    }

                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
        private async Task<ApiResponse> UploadImageToUserGallery(UploadImageRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                List<UploadFile> uploadFiles = new List<UploadFile>();
                //var user = await _userService.GetCurrentUser();

                foreach (var fileBase64 in request.FilesBase64)
                {
                    var uploadFile = new UploadFile();


                    byte[] fileBytes = Convert.FromBase64String(fileBase64.Base64);


                    MemoryStream stream = new MemoryStream(fileBytes);
                    IFormFile galleryImage = new FormFile(stream, 0, stream.Length, null, fileBase64.FileName)
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = fileBase64.ContentType
                    };

                    string trustedFileName = Path.GetRandomFileName();
                    string untrustedFileName = fileBase64.FileName;

                    var forumPostDir = Path.Combine(request.Dir, "Users", request.UserId.ToString(), "user-gallery");
                    if (!Directory.Exists(forumPostDir))
                    {
                        Directory.CreateDirectory(forumPostDir);
                    }
                    var pathFile = Path.Combine(forumPostDir, trustedFileName);

                    await using FileStream fs = new(pathFile, FileMode.Create);
                    await galleryImage.CopyToAsync(fs);

                    uploadFile.StoredFileName = trustedFileName;
                    uploadFile.FileName = untrustedFileName;
                    uploadFile.UserName = null;
                    uploadFile.UploadDate = DateTime.UtcNow;
                    uploadFiles.Add(uploadFile);

                    _context.UploadFiles.Add(uploadFile);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }


            return response;
        }
        private async Task<ApiResponse> UploadImageInBlogPost(UploadImageRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                List<UploadFile> uploadFiles = new List<UploadFile>();
                //var user = await _userService.GetCurrentUser();

                foreach (var file in request.Files)
                {
                    var uploadFile = new UploadFile();

                    string trustedFileName = Path.GetRandomFileName();
                    string untrustedFileName = file.FileName;

                    var blogPostDir = Path.Combine(request.Dir, "BlogPosts", request.BlogPostId.ToString());
                    if (!Directory.Exists(blogPostDir))
                    {
                        Directory.CreateDirectory(blogPostDir);
                    }
                    var pathFile = Path.Combine(blogPostDir, trustedFileName);

                    await using FileStream fs = new(pathFile, FileMode.Create);
                    await file.CopyToAsync(fs);

                    uploadFile.StoredFileName = trustedFileName;
                    uploadFile.FileName = untrustedFileName;
                    uploadFile.UserName = null;
                    uploadFile.UploadDate = DateTime.UtcNow;
                    uploadFiles.Add(uploadFile);

                    _context.UploadFiles.Add(uploadFile);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }


            return response;
        }
        private async Task<ApiResponse> UploadImageInStaticPage(UploadImageRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                List<UploadFile> uploadFiles = new List<UploadFile>();
                //var user = await _userService.GetCurrentUser();

                foreach (var file in request.Files)
                {
                    var uploadFile = new UploadFile();

                    string trustedFileName = Path.GetRandomFileName();
                    string untrustedFileName = file.FileName;

                    var staticPageDir = Path.Combine(request.Dir, "StaticPages", request.StaticPageId.ToString());
                    if (!Directory.Exists(staticPageDir))
                    {
                        Directory.CreateDirectory(staticPageDir);
                    }
                    var pathFile = Path.Combine(staticPageDir, trustedFileName);

                    await using FileStream fs = new(pathFile, FileMode.Create);
                    await file.CopyToAsync(fs);

                    uploadFile.StoredFileName = trustedFileName;
                    uploadFile.FileName = untrustedFileName;
                    uploadFile.UserName = null;
                    uploadFile.UploadDate = DateTime.UtcNow;
                    uploadFiles.Add(uploadFile);

                    _context.UploadFiles.Add(uploadFile);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
        private async Task<ApiResponse> UploadImageAsGeneralUse(UploadImageRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                List<UploadFile> uploadFiles = new List<UploadFile>();
                //var user = await _userService.GetCurrentUser();

                foreach (var file in request.Files)
                {
                    var uploadFile = new UploadFile();

                    string trustedFileName = Path.GetRandomFileName();
                    string untrustedFileName = file.FileName;

                    var generalUseDir = Path.Combine(request.Dir, "GeneralUse");
                    if (!Directory.Exists(generalUseDir))
                    {
                        Directory.CreateDirectory(generalUseDir);
                    }
                    var pathFile = Path.Combine(generalUseDir, trustedFileName);

                    await using FileStream fs = new(pathFile, FileMode.Create);
                    await file.CopyToAsync(fs);

                    uploadFile.StoredFileName = trustedFileName;
                    uploadFile.FileName = untrustedFileName;
                    uploadFile.UploadDate = DateTime.UtcNow;
                    uploadFile.UserName = null;

                    uploadFiles.Add(uploadFile);

                    _context.UploadFiles.Add(uploadFile);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private async Task<ApiResponse> UploadImageAsLogo(UploadImageRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                List<UploadFile> uploadFiles = new List<UploadFile>();

                //var user = await _userService.GetCurrentUser();

                foreach (var file in request.FilesBase64)
                {
                    bool isUpdate = false;

                    byte[] fileBytes = Convert.FromBase64String(file.Base64);

                    MemoryStream stream = new MemoryStream(fileBytes);
                    IFormFile galleryImage = new FormFile(stream, 0, stream.Length, null, "logo.png")
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = file.ContentType
                    };

                    var logoDir = Path.Combine(request.Dir, "Logo");
                    if (!Directory.Exists(logoDir))
                    {
                        Directory.CreateDirectory(logoDir);
                    }

                    var pathFile = Path.Combine(logoDir, "logo.png");
                    if (File.Exists(pathFile))
                    {
                        File.Delete(pathFile);
                        isUpdate = true;
                    }

                    await using FileStream fs = new(pathFile, FileMode.Create);
                    await galleryImage.CopyToAsync(fs);

                    if (isUpdate)
                    {
                        var updateUploadFile = await _context.UploadFiles.FirstOrDefaultAsync(x => x.StoredFileName == "logo.png");

                        if (updateUploadFile != null)
                        {
                            updateUploadFile.StoredFileName = "logo.png";
                            updateUploadFile.FileName = "logo.png";
                            updateUploadFile.UserName = null;
                            updateUploadFile.UploadDate = DateTime.UtcNow;
                            _context.UploadFiles.Update(updateUploadFile);
                        }
                    }
                    else
                    {
                        var uploadFile = new UploadFile();

                        uploadFile.StoredFileName = "logo.png";
                        uploadFile.FileName = "logo.png";
                        uploadFile.UserName = null;
                        uploadFile.UploadDate = DateTime.UtcNow;
                        uploadFiles.Add(uploadFile);
                        _context.UploadFiles.Add(uploadFile);
                    }

                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private async Task<ApiResponse> UploadImageAsFavicon(UploadImageRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                List<UploadFile> uploadFiles = new List<UploadFile>();

                //var user = await _userService.GetCurrentUser();

                foreach (var file in request.FilesBase64)
                {
                    bool isUpdate = false;

                    byte[] fileBytes = Convert.FromBase64String(file.Base64);

                    MemoryStream stream = new MemoryStream(fileBytes);
                    IFormFile galleryImage = new FormFile(stream, 0, stream.Length, null, "favicon.png")
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = file.ContentType
                    };

                    var logoDir = Path.Combine(request.Dir, "Favicon");
                    if (!Directory.Exists(logoDir))
                    {
                        Directory.CreateDirectory(logoDir);
                    }

                    var pathFile = Path.Combine(logoDir, "favicon.png");
                    if (File.Exists(pathFile))
                    {
                        File.Delete(pathFile);
                        isUpdate = true;
                    }

                    await using FileStream fs = new(pathFile, FileMode.Create);
                    await galleryImage.CopyToAsync(fs);

                    if (isUpdate)
                    {
                        var updateUploadFile = await _context.UploadFiles.FirstOrDefaultAsync(x => x.StoredFileName == "favicon.png");

                        if (updateUploadFile != null)
                        {
                            updateUploadFile.StoredFileName = "favicon.png";
                            updateUploadFile.FileName = "favicon.png";
                            updateUploadFile.UserName = null;
                            updateUploadFile.UploadDate = DateTime.UtcNow;
                            _context.UploadFiles.Update(updateUploadFile);
                        }
                    }
                    else
                    {
                        var uploadFile = new UploadFile();

                        uploadFile.StoredFileName = "favicon.png";
                        uploadFile.FileName = "favicon.png";
                        uploadFile.UserName = null;
                        uploadFile.UploadDate = DateTime.UtcNow;
                        uploadFiles.Add(uploadFile);
                        _context.UploadFiles.Add(uploadFile);
                    }

                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public List<string> GetImageUrlsFromGallery(string userId, string? dir)
        {
            var galleryDir = Path.Combine(dir, "Users", userId, "user-gallery");
            if (!Directory.Exists(galleryDir))
            {
                return new List<string>();
            }
            List<string> files = Directory.GetFiles(galleryDir).ToList();

            // Sadece dosya isimlerini almak için Path.GetFileName kullan
            List<string> fileNames = files.Select(file => Path.GetFileName(file)).ToList();

            return fileNames;
        }
    }
}
