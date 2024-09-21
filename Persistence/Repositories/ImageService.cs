using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Models;
using Application.Models.Enums;
using Application.Models.Persistence.Image;
using Domain;
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
            else if(request.Type == UploadImageType.ForumPost)
            {
                if (request.PostId == null)
                {
                    response.IsSuccess = false;
                    response.Message = "PostId is null";

                    return response;
                }
                response = await UploadImageInForumPost(request);
            }
            else if (request.Type == UploadImageType.BlogPost)
            {
                if (request.BlogPostId == null)
                {
                    response.IsSuccess = false;
                    response.Message = "BlogPostId is null";

                    return response;
                }

                response = await UploadImageInBlogPost(request);
            }
            else if (request.Type == UploadImageType.StaticPage)
            {
                if (request.StaticPageId == null)
                {
                    response.IsSuccess = false;
                    response.Message = "StaticPageId is null";

                    return response;
                }
                response = await UploadImageInStaticPage(request);
            }
            else if (request.Type == UploadImageType.GeneralUse)
            {
                response = await UploadImageAsGeneralUse(request);
            }

            return response;
        }

        private ApiResponse FirstControlOfImage(UploadImageRequest request)
        {
            ApiResponse response = new ApiResponse();

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
                    var uploadFile = new UploadFile();

                    string trustedFileName = Path.GetRandomFileName();
                    string untrustedFileName = file.FileName;

                    var userDir = Path.Combine(request.Dir, "Users", request.UserId.ToString(), "user-profile");
                    if (!Directory.Exists(userDir))
                    {
                        Directory.CreateDirectory(userDir);
                    }
                    var pathFile = Path.Combine(userDir, trustedFileName);

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
        private async Task<ApiResponse> UploadImageInForumPost(UploadImageRequest request)
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

                    var forumPostDir = Path.Combine(request.Dir, "ForumPosts", request.PostId.ToString());
                    if (!Directory.Exists(forumPostDir))
                    {
                        Directory.CreateDirectory(forumPostDir);
                    }
                    var pathFile = Path.Combine(forumPostDir, trustedFileName);

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
        
    }
}
