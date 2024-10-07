﻿using NarForumUser.Client.Models;
using NarForumUser.Client.Services.Base;

namespace NarForumUser.Client.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<ApiResponseVM> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}