using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.PublishBlogPost
{
    public class PublishBlogPostCommandHandler : IRequestHandler<PublishBlogPostCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;

        public PublishBlogPostCommandHandler(IMapper mapper, IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<ApiResponse> Handle(PublishBlogPostCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var blogPost = await _blogPostRepository.GetByIdAsync(request.Id!);

                if (blogPost != null)
                {
                    blogPost.IsPublished = true;
                    blogPost.IsDraft = false;

                    await _blogPostRepository.UpdateAsync(blogPost);

                    response.Message = "blog post is published";
                }
                else
                {
                    response.Message = "not found";
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
}
