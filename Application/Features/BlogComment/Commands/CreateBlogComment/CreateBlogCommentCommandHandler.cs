using Application.Contracts.Identity;
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
        private readonly IUserService _userService;

        public CreateBlogCommentCommandHandler(IMapper mapper, IBlogCommentRepository blogCommentRepository, IUserService userService)
        {
            _mapper = mapper;
            _blogCommentRepository = blogCommentRepository;
            _userService = userService;
        }

        public async Task<ApiResponse> Handle(CreateBlogCommentCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var user = await _userService.GetCurrentUser();

                if(user != null)
                {
                    var blogComment = _mapper.Map<Domain.BlogComment>(request);
                    blogComment.UserName = user.UserName;
                    if(user.Id != null)
                    {
                        blogComment.UserId = new Guid(user.Id);
                    }

                    await _blogCommentRepository.CreateAsync(blogComment);

                    response.Message = "Blog comment is added.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Comment cannot added due to comment's user not found";
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
