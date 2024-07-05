using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComment.Commands.UpdateBlogComment;

public class UpdateBlogCommentCommandHandler : IRequestHandler<UpdateBlogCommentCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IBlogCommentRepository _blogCommentRepository;

    public UpdateBlogCommentCommandHandler(IMapper mapper, IBlogCommentRepository blogCommentRepository)
    {
        _mapper = mapper;
        _blogCommentRepository = blogCommentRepository;
    }

    public async Task<ApiResponse> Handle(UpdateBlogCommentCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var blogComment = await _blogCommentRepository.GetByIdAsync(request.Id, true);

            if (blogComment != null)
            {
                blogComment.Content = request.Content;

                await _blogCommentRepository.UpdateAsync(blogComment);
                response.Message = "Blog comment is updated.";
            }
            else
            {
                response.Message = "Blog comment not found";
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
