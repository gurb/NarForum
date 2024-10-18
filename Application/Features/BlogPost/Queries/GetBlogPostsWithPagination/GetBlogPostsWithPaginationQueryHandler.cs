using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.BlogPost.Queries.GetBlogPosts;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPostsWithPagination;

public class GetBlogPostsWithPaginationQueryHandler : IRequestHandler<GetBlogPostsWithPaginationQuery, BlogPostsPaginationDTO>
{
    private readonly IMapper _mapper;
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IBlogCommentRepository _blogCommentRepository;
    private readonly ITrackingLogRepository _trackingLogRepository;
    public GetBlogPostsWithPaginationQueryHandler(IMapper mapper, IBlogPostRepository blogPostRepository, IBlogCommentRepository blogCommentRepository, ITrackingLogRepository trackingLogRepository)
    {
        _mapper = mapper;
        _blogPostRepository = blogPostRepository;
        _blogCommentRepository = blogCommentRepository;
        _trackingLogRepository = trackingLogRepository;
    }

    public async Task<BlogPostsPaginationDTO> Handle(GetBlogPostsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.True<Domain.BlogPost>();

        if (request.BlogCategoryId != null)
        {
            predicate = predicate.And(x => x.BlogCategoryId == request.BlogCategoryId);
        }

        if (request.SearchTitle != null)
        {
            predicate = predicate.And(x => x.Title.ToLower().Contains(request.SearchTitle.ToLower()));
        }

        if(request.Status == Models.Enums.BlogPostStatus.PUBLISHED)
        {
            predicate = predicate.And(x => x.IsPublished && !x.IsDraft);
        }

        if (request.Status == Models.Enums.BlogPostStatus.DRAFT)
        {
            predicate = predicate.And(x => x.IsDraft && !x.IsPublished);
        }

        List<Domain.BlogPost> blogPosts;

        Dictionary<string, bool> orderFunctions = new Dictionary<string, bool>
        {
            { "DateCreate",  true},
        };

        if (request.IsInclude)
        {
            blogPosts = await _blogPostRepository.GetBlogPostsWithPaginationIncludeBlogCategory(predicate, request.PageIndex.Value, request.PageSize.Value, orderFunctions);
        }
        else
        {
            blogPosts = await _blogPostRepository.GetWithPagination(predicate, request.PageIndex.Value, request.PageSize.Value);
        }

        var blogPostIds = blogPosts.Select(x => x.Id).ToList();

        var predicateComment = PredicateBuilder.True<Domain.BlogComment>();
        var predicateTrackingLog = PredicateBuilder.True<Domain.TrackingLog>();

        predicateTrackingLog = predicateTrackingLog.And(x => x.Type == Domain.Models.Enums.TrackingType.BLOG);
        foreach (var id in blogPostIds)
        {
            predicateComment = predicateComment.Or(x => x.BlogPostId == id);
            predicateTrackingLog = predicateTrackingLog.Or(x => x.TargetId == id);
        }

        var blogComments = await _blogCommentRepository.GetAllAsync(predicateComment);
        var trackingLogs = await _trackingLogRepository.GetAllAsync(predicateTrackingLog);

        var data = _mapper.Map<List<BlogPostDTO>>(blogPosts);

        foreach (var blogPost in data)
        {
            blogPost.CommentCounter = blogComments.Where(x => x.BlogPostId == blogPost.Id).Count();
            blogPost.ViewCounter = trackingLogs.Where(x => x.TargetId == blogPost.Id).Count();
        }

        BlogPostsPaginationDTO dto = new BlogPostsPaginationDTO
        {
            BlogPosts = data,
            TotalCount = _blogPostRepository.GetCount(predicate)
        };

        return dto;

    }
}
