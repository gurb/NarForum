using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.RemoveBlogPost;

public class RemoveBlogPostCommandHandler : IRequestHandler<RemoveBlogPostCommand, ApiResponse>
{

    private readonly IMapper _mapper;
    private readonly IBlogPostRepository _blogPostRepository;

    public RemoveBlogPostCommandHandler(IMapper mapper, IBlogPostRepository blogPostRepository)
    {
        _mapper = mapper;
        _blogPostRepository = blogPostRepository;
    }

    public async Task<ApiResponse> Handle(RemoveBlogPostCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var blogPost = await _blogPostRepository.GetByIdAsync(request.Id, true);

            if(blogPost != null)
            {
                blogPost.IsActive = !blogPost.IsActive;
                await _blogPostRepository.UpdateAsync(blogPost);
                response.Message = "Blog post is removed.";
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
