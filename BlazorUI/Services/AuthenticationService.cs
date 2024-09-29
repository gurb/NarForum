﻿using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models;
using BlazorUI.Providers;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorUI.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(IClient client, LocalStorageService localStorage, IMapper mapper, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _mapper = mapper;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password };
            var authenticationResponse = await _client.LoginAsync(authenticationRequest);

            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorage.AddItem("token", authenticationResponse.Token);
                string token = await _localStorage.GetItem("token");
                // Set claims in Blazor and login state
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

                return true;
            }
        }
        catch (Exception ex)
        {
            var tct = ex.Message.ToString();
            return false;
        }

        return false;
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
