using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Models.Identity.Message;
using Application.Models.Identity.Notification;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;

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

        private readonly IGarnetCacheService _cache;

        public CreatePostCommandHandler(IMapper mapper, 
            IPostRepository postRepository, 
            IUserService userService, 
            IHeadingRepository headingRepository, 
            ICategoryRepository categoryRepository, 
            IQuoteRepository quoteRepository,
            IGarnetCacheService cache)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _userService = userService;
            _headingRepository = headingRepository;
            _categoryRepository = categoryRepository;
            _quoteRepository = quoteRepository;
            _cache = cache;
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
            if (user.Id != null)
            {
                post.UserId = new Guid(user.Id);
            }

            // add to database
            await _postRepository.CreateAsync(post);

            var heading = await _headingRepository.GetByIdAsync(post.HeadingId!);


            if (heading != null)
            {
                await _headingRepository.UpdateHeadingWhenCreatePost(heading.Id, post.UserName, post.UserId.Value, post.Id);
                await _categoryRepository.UpdateCategoryWhenCreatePost(heading.CategoryId, post.UserName, post.UserId.Value, heading.Id, post.Id);
                await _headingRepository.IncreasePostCounter(post.HeadingId!);
                await _categoryRepository.IncreasePostCounter(post.HeadingId);

                if(post.UserId is not null && heading.UserId != post.UserId)
                {
                    await SendNotificationForHeading(heading.Id, heading.Title, user.UserName, user.Id, heading.UserName!, heading.UserId.ToString());
                }

                // add quotes
                if (request.QuotePostIds != null)
                {
                    var quotes = new List<Domain.Quote>();

                    foreach (var quoteId in request.QuotePostIds)
                    {
                        var quote = new Domain.Quote();
                        quote.QuotePostId = quoteId;
                        quote.PostId = post.Id;

                        var quotePost = await _postRepository.GetByIdAsync(quoteId);

                        if(quotePost is not null && quotePost.UserId != post.UserId)
                        {
                            await SendNotificationForReply(heading.Id, heading.Title, user.UserName, user.Id, quotePost.UserName!, quotePost.UserId.ToString());
                        }

                        quotes.Add(quote);
                    }

                    await _quoteRepository.CreateListAsync(quotes);
                }
            }

            // return record id
            return post.Id;
        }


        public async Task SendNotificationForHeading(Guid? headingId, string? headingTitle, string? username, string? userId, string ownerHeading, string? ownerHeadingId)
        {
            NotificationDTO notification = new NotificationDTO
            {
                Id = Guid.NewGuid().ToString(),
                Message = $"There is a new post for your {headingTitle} by {username}",
                HeadingId = headingId,
                Creator = new UserDTO { UserName = username },
                CreatorId = userId,
                Receiver = new UserDTO { UserName = ownerHeading },
                ReceiverId = ownerHeadingId,
                Type = Application.Models.Enums.NotificationType.RepliedHeading,
                DateTime = DateTime.UtcNow,
                IsRead = false,
            };

            var notificationRequest = JsonConvert.SerializeObject(notification);

            await _cache.AddHashSet("notifications", $"{ownerHeading}:{notification.Id}", notificationRequest);
        }

        public async Task SendNotificationForReply(Guid? headingId, string? headingTitle, string? username, string? userId, string ownerPost, string? ownerPostId)
        {
            NotificationDTO notification = new NotificationDTO
            {
                Id = Guid.NewGuid().ToString(),
                Message = $"There is a reply for your post at {headingTitle} by {username}",
                HeadingId = headingId,
                HeadingIndex = 0,
                Creator = new UserDTO { UserName = username },
                CreatorId = userId,
                Receiver = new UserDTO { UserName = ownerPost },
                ReceiverId = ownerPostId,
                Type = Application.Models.Enums.NotificationType.RepliedPost,
                DateTime = DateTime.UtcNow,
                IsRead = false,
            };

            var notificationRequest = JsonConvert.SerializeObject(notification);

            await _cache.AddHashSet("notifications", $"{ownerPost}:{notification.Id}", notificationRequest);
        }

    }
}
