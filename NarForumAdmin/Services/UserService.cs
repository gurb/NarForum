using AutoMapper;
using NarForumAdmin.Contracts;
using NarForumAdmin.Models.Category;
using NarForumAdmin.Models.User;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using NarForumAdmin.Models.Section;
using static System.Runtime.InteropServices.JavaScript.JSType;
using NarForumAdmin.Models;
using NarForumAdmin.Models.TrackingLog;

namespace NarForumAdmin.Services;

public class UserService : BaseHttpService, IUserService
{
    private readonly IMapper _mapper;
    public UserService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<ApiResponseVM> BlockUser(string? userId)
    {
        try
        {
            var response = await _client.BlockUserAsync(userId);
            return _mapper.Map<ApiResponseVM>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<UserInfoVM> GetUserInfo(string userName)
    {
        try
        {
            UserInfoRequest request = new UserInfoRequest
            {
                UserName = userName,
            };
            var userInfo = await _client.GetUserInfoAsync(request);
            var data = _mapper.Map<UserInfoVM>(userInfo);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<ApiUserRoleResponseVM> GetApiUserRole(GetApiUserRoleRequestVM request)
    {
        try
        {
            var req = _mapper.Map<GetApiUserRoleRequest>(request);

            var role = await _client.GetUserRoleAsync(req);
            var data = _mapper.Map<ApiUserRoleResponseVM>(role);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<UsersPaginationVM> GetWithPagination(UsersPaginationQueryVM paramQuery)
    {
        try
        {
            GetUsersWithPaginationQuery query = _mapper.Map<GetUsersWithPaginationQuery>(paramQuery);

            var usersPagination = await _client.GetUsersWithPaginationAsync(query);

            var data = _mapper.Map<UsersPaginationVM>(usersPagination);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<ApiResponseVM> UpdateUser(UpdateUserRequestVM request)
    {
        try
        {
            var req = _mapper.Map<UpdateUserRequest>(request);
            var response = await _client.UpdateUserAsync(req);
            return _mapper.Map<ApiResponseVM>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<ApiResponseVM> CreateResetPasswordRequest(ResetPasswordRequestVM request)
    {
        try
        {
            var req = _mapper.Map<ResetPasswordRequest>(request);
            var response = await _client.CreateResetPasswordRequestAsync(req);

            return _mapper.Map<ApiResponseVM>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<ApiResponseVM> CheckResetPasswordRequest(Guid? Id)
    {
        try
        {
            var response = await _client.CheckResetPasswordRequestAsync(Id);
            return _mapper.Map<ApiResponseVM>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<ApiResponseVM> ChangeUserPassword(Guid? Id, string? newPassword, string? confirmPassword)
    {
        try
        {
            var response = await _client.ChangeUserPasswordAsync(Id, newPassword, confirmPassword);
            return _mapper.Map<ApiResponseVM>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<ApiResponseVM> CreateConfirmRequest()
    {
        try
        {
            var response = await _client.CreateConfirmRequestAsync();
            return _mapper.Map<ApiResponseVM>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<ApiResponseVM> VerifyEmailAddress(Guid? Id)
    {
        try
        {
            var response = await _client.VerifyEmailAddressAsync(Id);
            return _mapper.Map<ApiResponseVM>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }
}

