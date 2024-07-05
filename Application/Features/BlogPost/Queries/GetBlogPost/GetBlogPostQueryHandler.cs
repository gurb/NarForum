using Application.Contracts.Persistence;
using Application.Features.BlogPost.Queries.GetBlogPosts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var blogPost = await _blogPostRepository.GetByIdAsync(request.Id);

            var data = _mapper.Map<BlogPostDTO>(blogPost);

            return data;
        }
    }
}
