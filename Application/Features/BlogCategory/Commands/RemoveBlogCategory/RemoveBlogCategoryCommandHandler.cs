using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogCategory.Commands.RemoveBlogCategory;

public class RemoveBlogCategoryCommandHandler : IRequestHandler<RemoveBlogCategoryCommand, ApiResponse>
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    private readonly IBlogPostRepository _blogPostRepository;

    public RemoveBlogCategoryCommandHandler(IBlogCategoryRepository blogCategoryRepository, IBlogPostRepository blogPostRepository)
    {
        _blogCategoryRepository = blogCategoryRepository;
        _blogPostRepository = blogPostRepository;
    }

    public async Task<ApiResponse> Handle(RemoveBlogCategoryCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var blogCategory = await _blogCategoryRepository.GetAsync(x => x.Id == request.Id);

            
            if(blogCategory != null)
            {

                var blogPosts = await _blogPostRepository.GetAllAsync(x => x.BlogCategoryId == blogCategory.Id, true);

                foreach (var blogPost in blogPosts)
                {
                    blogPost.BlogCategoryId = null;
                }

                _blogPostRepository.UpdateList(blogPosts);

                await _blogCategoryRepository.DeleteAsync(blogCategory);
                response.Message = "Blog category is removed.";
            }
            else
            {
                response.Message = "Not found blog category";
                response.IsSuccess = false;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }

        return response;
    }
}
