using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.UpdateBlogPost;

public class UpdateBlogPostCommandHandler: IRequestHandler<UpdateBlogPostCommand, ApiResponse>
{

    private readonly IMapper _mapper;
    private readonly IBlogPostRepository _blogPostRepository;

    public UpdateBlogPostCommandHandler(IMapper mapper, IBlogPostRepository blogPostRepository)
    {
        _mapper = mapper;
        _blogPostRepository = blogPostRepository;
    }

    public async Task<ApiResponse> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(request.Id, true);

            if (blogPost != null)
            {
                blogPost.Url = request.Url;
                blogPost.BlogCategoryId = request.BlogCategoryId;
                blogPost.Content = request.Content;
                
                await _blogPostRepository.UpdateAsync(blogPost);
                response.Message = "Blog post is updated.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Blog post not found.";
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
