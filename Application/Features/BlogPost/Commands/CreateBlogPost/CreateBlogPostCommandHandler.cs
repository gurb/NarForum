using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.CreateBlogPost;

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IBlogPostRepository _blogPostRepository;

    public CreateBlogPostCommandHandler(IMapper mapper, IBlogPostRepository blogPostRepository)
    {
        _mapper = mapper;
        _blogPostRepository = blogPostRepository;
    }
    public async Task<ApiResponse> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var blogPost = _mapper.Map<Domain.BlogPost>(request);
            blogPost.IsDraft = true;

            await _blogPostRepository.CreateAsync(blogPost);

            response.Message = "Blog post is created.";
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }

        return response;
    }
}
