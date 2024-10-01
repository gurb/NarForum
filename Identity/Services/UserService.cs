using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Models;
using Application.Models.Identity.User;
using Application.Models.Persistence.Image;
using Azure.Core;
using Identity.DatabaseContext;
using Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ForumUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ForumIdentityDbContext _identityDbContext;
        private readonly IImageService _imageService;
        private readonly IEmailSender _emailSender;

        public UserService(UserManager<ForumUser> userManager, IHttpContextAccessor contextAccessor, ForumIdentityDbContext identityDbContext, IImageService imageService, IEmailSender emailSender)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _identityDbContext = identityDbContext;
            _imageService = imageService;
            _emailSender = emailSender;
        }

        public string GetUserId()
        {
            return UserId;
        }

        public string UserId { get { return _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); } }

        public async Task<UserInfoResponse> GetCurrentUser()
        {
            string id = UserId;
            var currentUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            UserInfoResponse response = new UserInfoResponse
            {
                UserName = currentUser.UserName,
                Id = currentUser.Id,
                RegisterDate = currentUser.RegisterDate,
                EmailConfirmed = currentUser.EmailConfirmed,
            };

            return response;
        }

        public async Task<UserInfoResponse> GetUserInfo(UserInfoRequest request)
        {
            var user = await _identityDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == request.UserName);

            UserInfoResponse response;

            if (user is not null)
            {
                response = new UserInfoResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RegisterDate = user.RegisterDate,
                    Description = user.Description,
                    PostCounter = 100,
                    HeadingCounter = 10,
                    IsBlocked = user.IsBlocked,
                    Email = user.Email,
                };
            }
            else
            {
                response = new UserInfoResponse();
            }

            return response;
        }

        public async Task<ApiUserRoleResponse> GetUserRole(GetApiUserRoleRequest request)
        {
            var user = await _identityDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

            ApiUserRoleResponse response = new ApiUserRoleResponse();

            if (user is not null)
            {
                var userRole = await _identityDbContext.UserRoles.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == request.Id);

                if(userRole is not null)
                {
                    response.RoleId = userRole.RoleId;
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "user role not found";
                }
            }
            else
            {
                response = new ApiUserRoleResponse
                {
                    IsSuccess = false,
                    Message = "user not found",
                    RoleId = null
                };

            }

            return response;
        }

        public async Task<List<UserInfoResponse>> GetUserIdsByName(List<string> userNames)
        {
            var list = new List<UserInfoResponse>();
            var predicate = PredicateBuilder.True<ForumUser>();

            foreach (var username in userNames)
            {
                predicate = predicate.And(x => x.UserName == username);
            }

            var users = await _identityDbContext.Users.AsNoTracking()
                .Where(predicate)
                .Select(x => new UserInfoResponse
                {
                    Id = x.Id,
                    UserName = x.UserName,
                })
                .ToListAsync();

            return users;
        }

        public async Task<UsersPaginationDTO> GetWithPagination(GetUsersWithPaginationQuery query)
        {
            UsersPaginationDTO dto = new UsersPaginationDTO();

            var predicate = PredicateBuilder.True<ForumUser>();

            if(!String.IsNullOrEmpty(query.UserName))
            {
                predicate = predicate.And(x => x.UserName!.Contains(query.UserName));
            }

            var users = await _identityDbContext.Users.AsNoTracking()
                .Where(predicate)
                .Skip((query.PageIndex! - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(x => new UserInfoResponse
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        RegisterDate = x.RegisterDate,
                        Description = x.Description,
                        PostCounter = 100,
                        HeadingCounter = 10,
                        IsBlocked = x.IsBlocked,
                        Email = x.Email,
                }
                ).ToListAsync();
            
            dto.Users = users;
            dto.TotalCount = _identityDbContext.Users.AsNoTracking()
                .Where(predicate).Count();

            return dto;
        }



        public async Task<ApiResponse> ChangeUserSettings(ChangeUserSettingsRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var user = await GetCurrentUser();

                if(user != null)
                {

                    if(request.IsChangeImage)
                    {
                        if(request.ProfileImageBase64 != null && request.ContentType != null && request.FileName != null)
                        {
                            IFormFile? ProfileImage;

                            byte[] fileBytes = Convert.FromBase64String(request.ProfileImageBase64);


                            MemoryStream stream = new MemoryStream(fileBytes);
                            ProfileImage = new FormFile(stream, 0, stream.Length, null, request.FileName)
                            {
                                Headers = new HeaderDictionary(),
                                ContentType = request.ContentType
                            };

                            UploadImageRequest uploadRequest = new UploadImageRequest
                            {
                                UserId = new Guid(user.Id!),
                                Type = Application.Models.Enums.UploadImageType.UserProfile,
                                Dir = request.Dir,
                                Files = new List<IFormFile> { ProfileImage }
                            };

                            ApiResponse uploadResponse = await _imageService.UploadImageToServer(uploadRequest);

                            if (!uploadResponse.IsSuccess)
                            {
                                stream.Dispose();
                                return response;
                            }

                            stream.Dispose();
                        }
                    }

                    var updateUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                    bool isUpdate = false;

                    if (request.IsChangePassword)
                    {
                        if (updateUser != null)
                        {
                            if (request.NewPassword == request.ConfirmPassword)
                            {
                                var hasher = new PasswordHasher<ForumUser>();
                                updateUser.PasswordHash = hasher.HashPassword(null, request.NewPassword);
                                isUpdate = true;
                            }
                        }
                    }


                    if (user.UserName != request.UserName && request.UserName != null && request.UserName.Length > 3 && request.UserName.Length < 30)
                    {

                        if (updateUser != null)
                        {
                            var anyUser = await _identityDbContext
                                .Users
                                .AnyAsync
                                    (x => x.Id != user.Id && (x.UserName == request.UserName ||
                                     x.UserName.ToLower() == request.UserName.ToLower() ||
                                     x.UserName.ToUpper() == request.UserName.ToUpper()));

                            if (anyUser)
                            {
                                response.IsSuccess = false;
                                response.Message = "Username is already taken";

                                return response;
                            }
                            
                            updateUser.UserName = request.UserName;
                            isUpdate = true;
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = "User cannot find";
                        }
                    }

                    if(isUpdate && updateUser != null)
                    {
                        _identityDbContext.Users.Update(updateUser);
                        await _identityDbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Not found any authenticated user";
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }



        public async Task<ApiResponse> UpdateUser(UpdateUserRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var updateUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

                if(updateUser != null)
                {
                    if(request.UserName != updateUser.UserName)
                    {
                        var anyUsername = await _identityDbContext.Users.AnyAsync(x => x.Id != request.Id && x.UserName.ToLower() == request.UserName.ToLower());

                        if(anyUsername)
                        {
                            response.IsSuccess = false;
                            response.Message = "The username already exist";
                            return response;
                        }
                        
                        updateUser.UserName = request.UserName;
                    }

                    if(request.IsChangePassword && request.Password != null)
                    {
                        var hasher = new PasswordHasher<ForumUser>();
                        updateUser.PasswordHash = hasher.HashPassword(null, request.Password);
                    }

                    updateUser.FirstName = request.FirstName;
                    updateUser.LastName = request.LastName;
                    updateUser.Email = request.Email;
                    updateUser.Description = request.Description;

                    _identityDbContext.Users.Update(updateUser);
                    await _identityDbContext.SaveChangesAsync();
                    response.Message = "Updated user";

                }

            }
            catch (Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse> BlockUser(string? UserId)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var updateUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == UserId);

                if (updateUser != null)
                {
                    updateUser.IsBlocked = !updateUser.IsBlocked;

                    _identityDbContext.Users.Update(updateUser);
                    await _identityDbContext.SaveChangesAsync();

                    if(updateUser.IsBlocked)
                    {
                        response.Message = "Blocked user";
                    }
                    else
                    {
                        response.Message = "Unblocked user";
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "User not found";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ApiResponse> CreateResetPasswordRequest(ResetPasswordRequest request)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                if(string.IsNullOrEmpty(request.Email))
                {
                    response.IsSuccess = false;
                    response.Message = "Email is null or empty";
                    return response;
                }

                var updateUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

                if(updateUser != null)
                {
                    PasswordRequest passwordRequest = new PasswordRequest();
                    passwordRequest.Email = updateUser.Email;
                    passwordRequest.UserId = updateUser.Id;
                    passwordRequest.UserName = updateUser.UserName;

                    await _identityDbContext.PasswordRequests.AddAsync(passwordRequest);
                    await _identityDbContext.SaveChangesAsync();

                    var resetPasswordMessage = $"We've received a request to reset your password.\n\n" +
                                               $"If you did not make the request, just ignore this message. Otherwise, you can reset your password.\n\n" +
                                               $"Click the following link to reset password: https://localhost:7212/change-password/{passwordRequest.Id}";


                    if(passwordRequest.Email != null)
                    {
                        await _emailSender.SendMailToClient(passwordRequest.Email, "gurbforum", "Resetting your gurbforum account password!", resetPasswordMessage);
                    }

                    response.Message = "Maybe we sent :)";
                    return response;
                }
                else
                {
                    response.Message = "Maybe we sent :)";
                    return response;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        // if user did not confirm mail address, the user could send verify email address message again.
        public async Task<ApiResponse> CreateConfirmRequest()
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var currentUser = await GetCurrentUser();

                if(currentUser.EmailConfirmed)
                {
                    response.IsSuccess = false;
                    response.Message = "Already confirmed your email address";

                    return response;
                }
                else
                {
                    var updateUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == currentUser.Id);

                    if (updateUser != null)
                    {
                        ConfirmRequest confirmRequest = new ConfirmRequest();
                        confirmRequest.Email = updateUser.Email;
                        confirmRequest.UserName = updateUser.UserName;
                        confirmRequest.UserId = currentUser.Id;

                        await _identityDbContext.ConfirmRequests.AddAsync(confirmRequest);
                        await _identityDbContext.SaveChangesAsync();

                        var verifyEmailMessage = $"Dear {updateUser.UserName},\n\n" +
                                                   $"Thank you for signing up for gurbforum.com. We're excited to have you on board.\n\n" +
                                                   $"Please confirm that you want to use this as your gurbforum account email address. Once it's done you will be able to use our forum" +
                                                   $"Click the following link to confirm your email address: https://localhost:7212/verify-email-address/{confirmRequest.Id}";
                        
                        if(confirmRequest.Email != null)
                        {
                            await _emailSender.SendMailToClient(confirmRequest.Email, "gurbforum", "[gurbforum] Verify your email address!", verifyEmailMessage);
                        }
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "user not found";

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }


        // it will be used for after success user registration
        public async Task<ApiResponse> CreateConfirmRequestWithUserId(string? UserId)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var updateUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == UserId);

                if (updateUser != null)
                {
                    ConfirmRequest confirmRequest = new ConfirmRequest();
                    confirmRequest.Email = updateUser.Email;
                    confirmRequest.UserName = updateUser.UserName;
                    confirmRequest.UserId = updateUser.Id;

                    await _identityDbContext.ConfirmRequests.AddAsync(confirmRequest);
                    await _identityDbContext.SaveChangesAsync();

                    var verifyEmailMessage = $"Dear {updateUser.UserName},\n\n" +
                                                $"Thank you for signing up for gurbforum.com. We're excited to have you on board.\n\n" +
                                                $"Please confirm that you want to use this as your gurbforum account email address. Once it's done you will be able to use our forum" +
                                                $"Click the following link to confirm your email address: https://localhost:7212/verify-email-address/{confirmRequest.Id}";

                    if (confirmRequest.Email != null)
                    {
                        await _emailSender.SendMailToClient(confirmRequest.Email, "gurbforum", "[gurbforum] Verify your email address!", verifyEmailMessage);
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "user not found";

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ApiResponse> CheckResetPasswordRequest(Guid? Id)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                if(Id != null)
                {
                    PasswordRequest? passwordRequest = await _identityDbContext.PasswordRequests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);

                    if(passwordRequest != null)
                    {
                        if(passwordRequest.IsChanged)
                        {
                            response.IsSuccess = false;
                            response.Message = "Password is already changed";
                            return response;
                        }
                        if (!passwordRequest.IsValid)
                        {
                            response.IsSuccess = false;
                            response.Message = "Password reset operation is not valid anymore";
                            return response;
                        }
                        if(passwordRequest.IsValid && !passwordRequest.IsChanged)
                        {
                            response.Message = "Password can be changed";
                            return response;
                        }
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Not found a reset password request";
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Id is null";
                }
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ApiResponse> ChangeUserPassword(Guid? Id, string? newPassword, string? confirmPassword)
        {
            ApiResponse response = new ApiResponse();

            if(string.IsNullOrEmpty(newPassword))
            {
                response.IsSuccess = false;
                response.Message = "New password is empty";
                return response;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                response.IsSuccess = false;
                response.Message = "Confirm password is empty";
                return response;
            }

            if (newPassword != confirmPassword)
            {
                response.IsSuccess = false;
                response.Message = "Two passwords are not equal";
                return response;
            }


            try
            {
                if (Id != null)
                {
                    PasswordRequest? passwordRequest = await _identityDbContext.PasswordRequests.FirstOrDefaultAsync(x => x.Id == Id);
                    
                    if(passwordRequest != null)
                    {
                        if (!passwordRequest.IsChanged && passwordRequest.IsValid)
                        {
                            var updateUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == passwordRequest.UserId);

                            if (updateUser != null) 
                            {
                                var hasher = new PasswordHasher<ForumUser>();
                                updateUser.PasswordHash = hasher.HashPassword(null, newPassword);

                                _identityDbContext.Users.Update(updateUser);

                                passwordRequest.IsChanged = true;
                                passwordRequest.IsValid = false;

                                _identityDbContext.PasswordRequests.Update(passwordRequest);

                                await _identityDbContext.SaveChangesAsync();
                                response.Message = "User password is changed successfully";
                            }
                            else
                            {
                                response.IsSuccess = false;
                                response.Message = "User not found";
                                return response;
                            }
                        }
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Not found a reset password request";
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Id is null.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ApiResponse> VerifyEmailAddress(Guid? Id)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                ConfirmRequest? confirmRequest = await _identityDbContext.ConfirmRequests.FirstOrDefaultAsync(x => x.Id == Id);

                if(confirmRequest != null)
                {
                    if(confirmRequest.IsValid && !confirmRequest.IsVerified)
                    {
                        var updateUser = await _identityDbContext.Users.FirstOrDefaultAsync(x => x.Id == confirmRequest.UserId);

                        if(updateUser != null)
                        {
                            if(!updateUser.EmailConfirmed)
                            {
                                updateUser.EmailConfirmed = true;

                                _identityDbContext.Users.Update(updateUser);

                                confirmRequest.IsValid = false;
                                confirmRequest.IsVerified = true;
                                response.Message = "User's email address is verified successfully";
                            }
                            else
                            {
                                confirmRequest.IsValid = false;
                                confirmRequest.IsVerified = false;

                                response.IsSuccess = false;
                                response.Message = "User's mail is already verified";
                            }

                            _identityDbContext.ConfirmRequests.Update(confirmRequest);
                            await _identityDbContext.SaveChangesAsync();
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = "Not found user";
                        }
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Not found confirm request in the records";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }


    }
}
