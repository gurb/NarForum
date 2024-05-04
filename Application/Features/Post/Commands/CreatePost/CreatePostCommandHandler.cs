﻿using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly IHeadingRepository _headingRepository;
        private readonly IUserService _userService;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository, IUserService userService, IHeadingRepository headingRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _userService = userService;
            _headingRepository = headingRepository;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
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


            var heading = await _headingRepository.GetByIdAsync(post.HeadingId!.Value);

            if (heading != null)
            {
                await _headingRepository.IncreasePostCounter(post.HeadingId!.Value);
            }

            // return record id
            return post.Id;
        }
    }
}
