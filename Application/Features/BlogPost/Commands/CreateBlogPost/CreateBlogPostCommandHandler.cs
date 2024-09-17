using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.CreateBlogPost;

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IUserService _userService;

    public CreateBlogPostCommandHandler(IMapper mapper, IBlogPostRepository blogPostRepository, IUserService userService)
    {
        _mapper = mapper;
        _blogPostRepository = blogPostRepository;
        _userService = userService;
    }
    public async Task<ApiResponse> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var user = await _userService.GetCurrentUser();

            var blogPost = _mapper.Map<Domain.BlogPost>(request);
            blogPost.IsDraft = true;
            blogPost.UserName = user.UserName;

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
