using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Commands.DraftBlogPost
{
    public class DraftBlogPostCommandHandler : IRequestHandler<DraftBlogPostCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;

        public DraftBlogPostCommandHandler(IMapper mapper, IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<ApiResponse> Handle(DraftBlogPostCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var blogPost = await _blogPostRepository.GetByIdAsync(request.Id);

                if(blogPost != null)
                {
                    blogPost.IsDraft = true;
                    blogPost.IsPublished = false;

                    await _blogPostRepository.UpdateAsync(blogPost);

                    response.Message = "blog post is  draft";
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
