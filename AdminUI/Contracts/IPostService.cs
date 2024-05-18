﻿using AdminUI.Models.Post;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
{
    public interface IPostService
    {
        // queries
        Task<List<PostVM>> GetPosts();
        Task<List<PostVM>> GetPostsByHeadingId(int id);
        Task<PostsPaginationVM> GetPostsByHeadingIdWithPagination(int id, int pageIndex, int pageSize);
        Task<PostsPaginationVM> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize);



        // commands
        Task<ApiResponse<Guid>> CreatePost(PostVM post);
    }
}