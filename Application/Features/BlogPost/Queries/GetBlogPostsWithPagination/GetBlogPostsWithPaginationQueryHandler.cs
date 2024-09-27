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
    public GetBlogPostsWithPaginationQueryHandler(IMapper mapper, IBlogPostRepository blogPostRepository)
    {
        _mapper = mapper;
        _blogPostRepository = blogPostRepository;
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

        var data = _mapper.Map<List<BlogPostDTO>>(blogPosts);

        BlogPostsPaginationDTO dto = new BlogPostsPaginationDTO
        {
            BlogPosts = data,
            TotalCount = _blogPostRepository.GetCount(predicate)
        };

        return dto;

    }
}
