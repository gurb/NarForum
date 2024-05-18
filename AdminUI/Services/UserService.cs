using AutoMapper;
using AdminUI.Contracts;
using AdminUI.Models.Category;
using AdminUI.Models.User;
using AdminUI.Services.Base;
using AdminUI.Services.Common;

namespace AdminUI.Services;

public class UserService : BaseHttpService, IUserService
{
    private readonly IMapper _mapper;
    public UserService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
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
}

