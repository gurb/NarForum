using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.BlogPost.Queries.GetBlogPosts;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPost
{
    public class GetBlogPostQueryHandler : IRequestHandler<GetBlogPostQuery, BlogPostDTO>
    {

        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IBlogCommentRepository _blogCommentRepository;
        private readonly ITrackingLogRepository _trackingLogRepository;

        public GetBlogPostQueryHandler(IMapper mapper, IBlogPostRepository blogPostRepository, IBlogCommentRepository blogCommentRepository, ITrackingLogRepository trackingLogRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
            _blogCommentRepository = blogCommentRepository;
            _trackingLogRepository = trackingLogRepository;
        }

        public async Task<BlogPostDTO> Handle(GetBlogPostQuery request, CancellationToken cancellationToken)
        {
            BlogPostDTO dto = new BlogPostDTO();

            if(request.Id != null)
            {
                var blogPost = await _blogPostRepository.GetByIdWithBlogCategoryAsync(request.Id.Value);
                dto = _mapper.Map<BlogPostDTO>(blogPost);
            }
            else if(request.IntId != null)
            {
                var blogPost = await _blogPostRepository.GetByIntIdWithBlogCategoryAsync(request.IntId.Value);
                dto = _mapper.Map<BlogPostDTO>(blogPost);
            }

            var predicateComment = PredicateBuilder.True<Domain.BlogComment>();
            var predicateTrackingLog = PredicateBuilder.True<Domain.TrackingLog>();

            predicateTrackingLog = predicateTrackingLog.And(x => x.Type == Domain.Models.Enums.TrackingType.BLOG);
            predicateComment = predicateComment.And(x => x.BlogPostId == dto.Id);
            predicateTrackingLog = predicateTrackingLog.And(x => x.TargetId == dto.Id);

            var blogComments = await _blogCommentRepository.GetAllAsync(predicateComment);
            var trackingLogs = await _trackingLogRepository.GetAllAsync(predicateTrackingLog);

            if(blogComments is not null)
            {
                dto.CommentCounter = blogComments.Count();
            }
            if(trackingLogs is not null)
            {
                dto.ViewCounter = trackingLogs.Count();
            }

            return dto;
        }
    }
}
