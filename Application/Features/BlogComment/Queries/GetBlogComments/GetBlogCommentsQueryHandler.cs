using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogComment.Queries.GetBlogComments;

public class GetBlogCommentsQueryHandler : IRequestHandler<GetBlogCommentsQuery, List<BlogCommentDTO>>
{
    private readonly IMapper _mapper;
    private readonly IBlogCommentRepository _blogCommentRepository;

    public GetBlogCommentsQueryHandler(IMapper mapper, IBlogCommentRepository blogCommentRepository)
    {
        _mapper = mapper;
        _blogCommentRepository = blogCommentRepository;
    }

    public async Task<List<BlogCommentDTO>> Handle(GetBlogCommentsQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.True<Domain.BlogComment>();

        if(request.BlogPostId != null)
        {
            predicate = predicate.And(x => x.BlogPostId == request.BlogPostId);
        }

        var data = await _blogCommentRepository.GetAllAsync(predicate);
        var blogComments = _mapper.Map<List<BlogCommentDTO>>(request);

        return blogComments;
    }
}
