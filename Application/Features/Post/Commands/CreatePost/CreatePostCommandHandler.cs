using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IHeadingRepository _headingRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserService _userService;

        private readonly IQuoteRepository _quoteRepository;

        public CreatePostCommandHandler(IMapper mapper, 
            IPostRepository postRepository, 
            IUserService userService, 
            IHeadingRepository headingRepository, 
            ICategoryRepository categoryRepository, 
            IQuoteRepository quoteRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _userService = userService;
            _headingRepository = headingRepository;
            _categoryRepository = categoryRepository;
            _quoteRepository = quoteRepository;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            var validator = new CreatePostCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Post", validationResult);
            }

            // convert to domain entity object
            var post = _mapper.Map<Domain.Post>(request);

            var user = await _userService.GetCurrentUser();
            var lastPost = await _postRepository.GetLastPost(post.HeadingId);

            if(lastPost != null)
            {
                post.HeadingIndex = lastPost.HeadingIndex + 1;
            }

            post.UserName = user.UserName;

            // add to database
            await _postRepository.CreateAsync(post);

            var heading = await _headingRepository.GetByIdAsync(post.HeadingId!);


            if (heading != null)
            {
                await _headingRepository.UpdateHeadingWhenCreatePost(heading.Id, post.UserName, post.Id);
                await _categoryRepository.UpdateCategoryWhenCreatePost(heading.CategoryId, post.UserName, heading.Id, post.Id);
                await _headingRepository.IncreasePostCounter(post.HeadingId!);
                await _categoryRepository.IncreasePostCounter(post.HeadingId);

                // add quotes
                if(request.QuotePostIds != null)
                {
                    var quotes = new List<Domain.Quote>();

                    foreach (var quoteId in request.QuotePostIds)
                    {
                        var quote = new Domain.Quote();
                        quote.QuotePostId = quoteId;
                        quote.PostId = post.Id;
                        
                        quotes.Add(quote);
                    }

                    await _quoteRepository.CreateListAsync(quotes);
                }
            }

            // return record id
            return post.Id;
        }
    }
}
