﻿using NarForumAdmin.Models;
using NarForumAdmin.Models.BlogPost;

namespace NarForumAdmin.Contracts;

public interface IBlogPostService
{
    Task<List<BlogPostVM>> GetBlogPosts(GetBlogPostsQueryVM request);
    Task<BlogPostVM> GetBlogPost(GetBlogPostQueryVM request);
    Task<BlogPostsPaginationVM> GetBlogPostsWithPagination(GetBlogPostsWithPaginationQueryVM request);
    Task<ApiResponseVM> CreateBlogPost(CreateBlogPostCommandVM command);
    Task<ApiResponseVM> UpdateBlogPost(UpdateBlogPostCommandVM command);
    Task<ApiResponseVM> RemoveBlogPost(RemoveBlogPostCommandVM command);
    Task<ApiResponseVM> PublishBlogPost(PublishBlogPostCommandVM command);
    Task<ApiResponseVM> DraftBlogPost(DraftBlogPostCommandVM command);
}
