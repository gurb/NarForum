using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Post.Queries.GetAllPosts;
using AutoMapper;
using MediatR;

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
            List<PostDTO>? quotePosts = new List<PostDTO>();
            PostsPaginationDTO? dto = new PostsPaginationDTO();

            var predicate = PredicateBuilder.True<Domain.Post>();

            //predicate = predicate.And(x => x.IsActive);

            if(request.PostId != null)
            {
                predicate = predicate.And(x => x.Id == request.PostId);
            }

            if(request.HeadingId != null)
            {
                predicate = predicate.And(x => x.HeadingId == request.HeadingId);
            }
            if(!String.IsNullOrEmpty(request.UserName))
            {
                predicate = predicate.And(x => x.UserName == request.UserName);
            }

            if(request.SearchContent != null)
            {
                predicate = predicate.And(x => x.Content.ToLower().Contains(request.SearchContent.ToLower()));
            }

            if (request.SearchUsername != null)
            {
                predicate = predicate.And(x => x.UserName.ToLower().Contains(request.SearchUsername.ToLower()));
            }

            posts = await _postRepository.GetPostsWithPagination(predicate, request.PageIndex!.Value, request.PageSize!.Value);

            var data = _mapper.Map<List<PostDTO>>(posts);

            if(data != null && data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (!data[i].IsActive && !request.IsAdminPanel) 
                    {
                        data[i].Content = string.Empty;
                    }
                    data[i].HeadingIndex = i;
                }
            }

            if(request.HeadingId != null)
            {
                // get quotes bounded with post
                quotePosts = new List<PostDTO>();
                List<Guid> PostIds = posts.Select(x => x.Id).ToList();
                List<Domain.Quote> quotes = await _quoteRepository.GetAllAsync(x => PostIds.Contains(x.PostId!));

                if (quotes != null && quotes.Count > 0)
                {
                    List<Guid> QuotePostIds = quotes.Select(x => x.QuotePostId).ToList();
                    var quotePostList = await _postRepository.GetAllAsync(x => QuotePostIds.Contains(x.Id));
                    quotePosts = _mapper.Map<List<PostDTO>>(quotePostList);
                }
            }

            if (!String.IsNullOrEmpty(request.UserName) || request.IsWithHeading)
            {
                List<Guid> headingIds = posts.Select(x => x.HeadingId).ToList();
                List<Domain.Heading> headings = await _headingRepository.GetAllAsync(x => headingIds.Contains(x.Id));

                List<Guid> categoryIds = headings.Select(x => x.CategoryId).ToList();
                List<Domain.Category> categories = await _categoryRepository.GetAllAsync(x => categoryIds.Contains(x.Id));

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
                            post.CategoryIntId = category.CategoryId;
                        }
                    }
            
                }
            }

            dto = new PostsPaginationDTO
            {
                Posts = data,
                QuotePosts = quotePosts,
                TotalCount = _postRepository.GetCount(predicate)
            };

            // return list of DTOs
            return dto;
        }
    }
}
