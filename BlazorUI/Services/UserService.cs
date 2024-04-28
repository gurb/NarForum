using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models.Category;
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

    public async Task<UserInfoVM> GetUserInfo(int userId)
    {
        UserInfoRequest request = new UserInfoRequest();
        request.UserId = userId;
        var userInfo = await _client.GetUserInfoAsync(request);
        var data = _mapper.Map<UserInfoVM>(userInfo);

        return data;
    }
}
