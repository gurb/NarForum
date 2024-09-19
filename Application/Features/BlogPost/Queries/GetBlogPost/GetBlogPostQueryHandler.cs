using Application.Contracts.Persistence;
using Application.Features.BlogPost.Queries.GetBlogPosts;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPost
{
    public class GetBlogPostQueryHandler : IRequestHandler<GetBlogPostQuery, BlogPostDTO>
    {

        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;

		public GetBlogPostQueryHandler(IMapper mapper, IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
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

            return dto;
        }
    }
}
