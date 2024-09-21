using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models;
using BlazorUI.Models.User;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services;

public class UserService : BaseHttpService, IUserService
{
    private readonly IMapper _mapper;
    public UserService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<ApiResponseVM> ChangeUserSettings(ChangeUserSettingsRequestVM request)
    {
        var req = _mapper.Map<ChangeUserSettingsRequest>(request);
        var response = await _client.ChangeUserSettingsAsync(req);

        return _mapper.Map<ApiResponseVM>(response);
    }

    public async Task<UserInfoVM> GetUserInfo(string userName)
    {
        UserInfoRequest request = new UserInfoRequest 
        {
            UserName = userName,
        };
        var userInfo = await _client.GetUserInfoAsync(request);
        var data = _mapper.Map<UserInfoVM>(userInfo);

        return data;
    }

    public async Task<UsersPaginationVM> GetUsersByUsernameWithPagination(string? userName, int pageIndex, int pageSize)
    {
        GetUsersWithPaginationQuery query = new GetUsersWithPaginationQuery
        {
            UserName = userName,
            PageIndex = pageIndex,
            PageSize = pageSize
        };

        var usersPagination = await _client.GetUsersWithPaginationAsync(query);

        var data = _mapper.Map<UsersPaginationVM>(usersPagination);

        return data;
    }

    
}
