using Application.Contracts.Persistence;
using Application.Features.Heading.Queries;
using Application.Features.Post.Queries.GetAllPosts;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Queries.GetPost
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IHeadingRepository _headingRepository;
        private readonly IQuoteRepository _quoteRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetPostQueryHandler(IMapper mapper, IPostRepository postRepository, IHeadingRepository headingRepository, IQuoteRepository quoteRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _headingRepository = headingRepository;
            _quoteRepository = quoteRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<PostDTO> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            // query the database
            Domain.Post post;
            post = await _postRepository.GetByIdAsync(request.Id);
           
            // convert data objecs to DTOs
            var data = _mapper.Map<PostDTO>(post);

            var heading = await _headingRepository.GetByIdAsync(data.HeadingId);

            if(heading != null)
            {
                data.HeadingDTO = _mapper.Map<HeadingDTO>(heading);

                var category = await _categoryRepository.GetByIdAsync(heading.CategoryId);

                if (category != null) 
                {
                    data.HeadingDTO.CategoryIntId = category.CategoryId;
                    data.HeadingDTO.CategoryName = category.Name;
                }
            }

            List<Domain.Quote> quotes = await _quoteRepository.GetAllAsync(x => x.PostId == data.Id);

            if (quotes != null && quotes.Count > 0)
            {
                List<Guid> QuotePostIds = quotes.Select(x => x.QuotePostId).ToList();
                var quotePostList = await _postRepository.GetAllAsync(x => QuotePostIds.Contains(x.Id));
                data.QuotePosts = _mapper.Map<List<PostDTO>>(quotePostList);
            }

            return data;
        }
    }
}
