using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogComment.Commands.RemoveBlogComment;

public class RemoveBlogCommentCommandHandler : IRequestHandler<RemoveBlogCommentCommand, ApiResponse>
{

    private readonly IMapper _mapper;
    private readonly IBlogCommentRepository _blogCommentRepository;
    public RemoveBlogCommentCommandHandler(IMapper mapper, IBlogCommentRepository blogCommentRepository)
    {
        _mapper = mapper;
        _blogCommentRepository = blogCommentRepository;
    }

    public async Task<ApiResponse> Handle(RemoveBlogCommentCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var blogComment = await _blogCommentRepository.GetByIdAsync(request.Id, true);

            if(blogComment != null)
            {
                blogComment.IsActive = !blogComment.IsActive;

                await _blogCommentRepository.UpdateAsync(blogComment);
                response.Message = "Blog comment is removed.";
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
