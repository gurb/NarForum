using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.BlogComment.Queries.GetBlogComments;
using AutoMapper;
using MediatR;


namespace Application.Features.BlogComment.Queries.GetBlogCommentsWithPagination;

public class GetBlogCommentsWithPaginationQueryHandler : IRequestHandler<GetBlogCommentsWithPaginationQuery, BlogCommentsPaginationDTO>
{

    private readonly IMapper _mapper;
    private readonly IBlogCommentRepository _blogCommentRepository;

    public GetBlogCommentsWithPaginationQueryHandler(IMapper mapper, IBlogCommentRepository blogCommentRepository)
    {
        _mapper = mapper;
        _blogCommentRepository = blogCommentRepository;
    }

    public async Task<BlogCommentsPaginationDTO> Handle(GetBlogCommentsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.True<Domain.BlogComment>();

        if (request.BlogPostId != null)
        {
            predicate = predicate.And(x => x.BlogPostId == request.BlogPostId);
        }

        var blogComments = await _blogCommentRepository.GetWithPagination(predicate, request.PageIndex!.Value, request.PageSize!.Value);

        var data = _mapper.Map<List<BlogCommentDTO>>(blogComments);

        BlogCommentsPaginationDTO dto = new BlogCommentsPaginationDTO
        {
            BlogComments = data,
            TotalCount = _blogCommentRepository.GetCount(predicate),
        };

        return dto;
    }
}
