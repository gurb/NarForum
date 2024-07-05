using Application.Contracts.Persistence;
using Application.Extensions.Core;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPosts;

public class GetBlogPostsQueryHandler : IRequestHandler<GetBlogPostsQuery, List<BlogPostDTO>>
{
    private readonly IMapper _mapper;
    private readonly IBlogPostRepository _blogPostRepository;

    public GetBlogPostsQueryHandler(IMapper mapper, IBlogPostRepository blogPostRepository)
    {
        _mapper = mapper;
        _blogPostRepository = blogPostRepository;
    }

    public async Task<List<BlogPostDTO>> Handle(GetBlogPostsQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.True<Domain.BlogPost>();

        if(request.BlogCategoryId != null)
        {
            predicate = predicate.And(x => x.BlogCategoryId == request.BlogCategoryId);
        }

        var blogPosts = await _blogPostRepository.GetAllAsync(predicate);

        var data = _mapper.Map<List<BlogPostDTO>>(blogPosts);

        return data;
    }
}
