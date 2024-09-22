﻿using Application.Models;
using Application.Models.Identity.User;
using System.Linq.Expressions;


namespace Application.Contracts.Identity
{
    public interface IUserService
    {
        public string UserId { get; }

        public string GetUserId();
        public Task<UserInfoResponse> GetUserInfo(UserInfoRequest request);

        public Task<UserInfoResponse> GetCurrentUser();
        public Task<List<UserInfoResponse>> GetUserIdsByName(List<string> userNames);
        public Task<UsersPaginationDTO> GetWithPagination(GetUsersWithPaginationQuery query);

        public Task<ApiResponse> ChangeUserSettings(ChangeUserSettingsRequest request);

    }
}
