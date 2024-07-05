using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogCategory.Commands.UpdateBlogCategory;

public class UpdateBlogCategoryCommandHandler : IRequestHandler<UpdateBlogCategoryCommand, ApiResponse>
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;

    public UpdateBlogCategoryCommandHandler(IBlogCategoryRepository blogCategoryRepository)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }

    public async Task<ApiResponse> Handle(UpdateBlogCategoryCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var blogCategory = await _blogCategoryRepository.GetAsync(x => x.Id == request.Id);

            if (blogCategory != null)
            {
                blogCategory.Name = request.Name;

                await _blogCategoryRepository.UpdateAsync(blogCategory);
                response.Message = "Blog category is updated.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Not found blog category.";
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