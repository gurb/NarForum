﻿using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models;
using NarForumUser.Client.Providers;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;
using Microsoft.AspNetCore.Components.Authorization;
using NarForumUser.Client.Models.Authentication;

namespace NarForumUser.Client.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(IClient client, LocalStorageService localStorage, IMapper mapper, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _mapper = mapper;
    }

    public async Task<AuthResponseVM> AuthenticateAsync(string email, string password)
    {
        AuthResponseVM response = new AuthResponseVM();
        response.IsSuccess = false;
        response.Message = string.Empty;
        try
        {
            AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password };
            var authenticationResponse = await _client.LoginAsync(authenticationRequest);
            response = _mapper.Map<AuthResponseVM>(authenticationResponse);

            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorage.AddItem("token", authenticationResponse.Token);
                string token = await _localStorage.GetItem("token");
                // Set claims in Blazor and login state
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

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

    public async Task Logout()
    {
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
    }

    public async Task<ApiResponseVM> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, UserName = userName, Email = email, Password = password };

        var response = await _client.RegisterAsync(registrationRequest);

        return _mapper.Map<ApiResponseVM>(response);
    }
}
