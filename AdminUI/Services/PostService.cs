﻿using AutoMapper;
using AdminUI.Contracts;
using AdminUI.Models.Post;
using AdminUI.Services.Base;
using AdminUI.Services.Common;

namespace AdminUI.Services;

public class PostService : BaseHttpService, IPostService
{
    private readonly IMapper _mapper;

    public PostService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<ApiResponse<Guid>> CreatePost(PostVM post)
    {
        try
        {
            var createPostCommand = _mapper.Map<CreatePostCommand>(post);
            await _client.PostsAsync(createPostCommand);
            return new ApiResponse<Guid>
            {
                Success = true
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<List<PostVM>> GetPosts()
    {
        var posts = await _client.PostsAllAsync();
        var data = _mapper.Map<List<PostVM>>(posts);

        return data;
    }

    public async Task<List<PostVM>> GetPostsByHeadingId(int id)
    {
        var posts = await _client.GetPostsByHeadingIdAsync(id);
        var data = _mapper.Map<List<PostVM>>(posts);

        return data;
    }

    public async Task<PostsPaginationVM> GetPostsByHeadingIdWithPagination(int id, int pageIndex, int pageSize)
    {
        var postsPagination = await _client.GetPostsByHeadingIdWithPaginationAsync(id, pageIndex, pageSize);

        var data = _mapper.Map<PostsPaginationVM>(postsPagination);

        return data;
    }

    public async Task<PostsPaginationVM> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize)
    {
        var postsPagination = await _client.GetPostsByUserNameWithPaginationAsync(userName, pageIndex, pageSize);

        var data = _mapper.Map<PostsPaginationVM>(postsPagination);

        return data;
    }
}