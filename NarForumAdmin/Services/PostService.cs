﻿using AutoMapper;
using NarForumAdmin.Contracts;
using NarForumAdmin.Models.Post;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;

namespace NarForumAdmin.Services;

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
        try
        {
            var posts = await _client.PostsAllAsync();
            var data = _mapper.Map<List<PostVM>>(posts);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<List<PostVM>> GetPostsByHeadingId(Guid id)
    {
        try
        {
            var posts = await _client.GetPostsByHeadingIdAsync(id);
            var data = _mapper.Map<List<PostVM>>(posts);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<PostsPaginationVM> GetPostsByHeadingIdWithPagination(Guid id, int pageIndex, int pageSize)
    {
        try
        {
            var postsPagination = await _client.GetPostsByHeadingIdWithPaginationAsync(id, pageIndex, pageSize);

            var data = _mapper.Map<PostsPaginationVM>(postsPagination);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<PostsPaginationVM> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize)
    {
        try
        {
            var postsPagination = await _client.GetPostsByUserNameWithPaginationAsync(userName, pageIndex, pageSize);

            var data = _mapper.Map<PostsPaginationVM>(postsPagination);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<PostsPaginationVM> GetPostsWithPagination(PostPaginationQueryVM paramQuery)
    {
        try
        {
            GetPostsWithPaginationQuery query = _mapper.Map<GetPostsWithPaginationQuery>(paramQuery);

            var postsPagination = await _client.GetPostsWithPaginationAsync(query);

            var data = _mapper.Map<PostsPaginationVM>(postsPagination);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task RemovePost(RemovePostCommandVM post)
    {
        try
        {
            RemovePostCommand command = _mapper.Map<RemovePostCommand>(post);
            await _client.RemovePostAsync(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }
}