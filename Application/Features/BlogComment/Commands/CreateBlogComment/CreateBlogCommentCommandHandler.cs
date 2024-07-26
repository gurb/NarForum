using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogComment.Commands.CreateBlogComment
{
    public class CreateBlogCommentCommandHandler : IRequestHandler<CreateBlogCommentCommand, ApiResponse>
    {

        private readonly IMapper _mapper;
        private readonly IBlogCommentRepository _blogCommentRepository;
        public CreateBlogCommentCommandHandler(IMapper mapper, IBlogCommentRepository blogCommentRepository)
        {
            _mapper = mapper;
            _blogCommentRepository = blogCommentRepository;
        }

        public async Task<ApiResponse> Handle(CreateBlogCommentCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var blogComment = _mapper.Map<Domain.BlogComment>(request);

                await _blogCommentRepository.CreateAsync(blogComment);

                response.Message = "Blog comment is added.";
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
