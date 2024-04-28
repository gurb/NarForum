using AutoMapper;
using BlazorUI.Contracts;
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
}
