using Application.Contracts.Persistence;
using Application.Features.Post.Queries.GetAllPosts;
using AutoMapper;
using MediatR;
using System.Linq;

namespace Application.Features.Post.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationQueryHandler : IRequestHandler<GetPostsWithPaginationQuery, PostsPaginationDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHeadingRepository _headingRepository;
        private readonly IQuoteRepository _quoteRepository;

        public GetPostsWithPaginationQueryHandler(
            IMapper mapper, 
            IPostRepository postRepository, 
            IHeadingRepository headingRepository, 
            ICategoryRepository categoryRepository, 
            IQuoteRepository quoteRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _headingRepository = headingRepository;
            _quoteRepository = quoteRepository;
        }

        public async Task<PostsPaginationDTO> Handle(GetPostsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            // query the database
            List<Domain.Post> posts;
            PostsPaginationDTO? dto = new PostsPaginationDTO();

            if (request.HeadingId != null)
            {
                posts = await _postRepository.GetPostsByHeadingIdWithPagination(request.HeadingId!.Value, request.PageIndex!.Value, request.PageSize!.Value);

                // convert data objecs to DTOs
                var data = _mapper.Map<List<PostDTO>>(posts);


                // get quotes bounded with post
                List<PostDTO> quotePosts = new List<PostDTO>();
                List<int> PostIds = posts.Select(x => x.Id).ToList();
                List<Domain.Quote> quotes = await _quoteRepository.GetAllAsync(x => PostIds.Contains(x.PostId!.Value));
                
                if(quotes != null && quotes.Count > 0)
                {
                    List<int?> QuotePostIds = quotes.Select(x => x.QuotePostId).ToList();
                    var quotePostList = await _postRepository.GetAllAsync(x => QuotePostIds.Contains(x.Id));
                    quotePosts = _mapper.Map<List<PostDTO>>(quotePostList);
                }


                dto = new PostsPaginationDTO
                {
                    Posts = data,
                    QuotePosts = quotePosts,
                    TotalCount = _postRepository.GetPostsCountByHeadingId(request.HeadingId.Value)
                };
            }

            if(request.UserName != null)
            {
                posts = await _postRepository.GetPostsByUserNameWithPagination(request.UserName, request.PageIndex!.Value, request.PageSize!.Value);

                List<int?> headingIds = posts.Select(x => x.HeadingId).ToList();
                List<Domain.Heading> headings = await _headingRepository.GetAllAsync(x => headingIds.Contains(x.Id));

                List<int> categoryIds = headings.Select(x => x.CategoryId).ToList();
                List<Domain.Category> categories = await _categoryRepository.GetAllAsync(x => categoryIds.Contains(x.Id));

                // convert data objecs to DTOs
                var data = _mapper.Map<List<PostDTO>>(posts);

                foreach (var post in data)
                {
                    var heading = headings.FirstOrDefault(x => x.Id == post.HeadingId);
                    if (heading != null)
                    {
                        post.HeadingTitle = heading.Title;

                        var category = categories.FirstOrDefault(x => x.Id == heading.CategoryId);
                        
                        if (category != null)
                        {
                            post.CategoryName = category.Name;
                        }
                    }
                }

                dto = new PostsPaginationDTO
                {
                    Posts = data,
                    TotalCount = _postRepository.GetPostsCountByUserName(request.UserName)
                };
            }


            // return list of DTOs
            return dto;
        }
    }
}
