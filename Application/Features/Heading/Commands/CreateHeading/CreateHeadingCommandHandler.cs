using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Heading.Commands.CreateHeading
{
    public class CreateHeadingCommandHandler : IRequestHandler<CreateHeadingCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHeadingRepository _HeadingRepository;
        private readonly IPostRepository _PostRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IUserService _userService;

        public CreateHeadingCommandHandler(IMapper mapper, IHeadingRepository HeadingRepository, IPostRepository PostRepository, IUserService userService, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _HeadingRepository = HeadingRepository;
            _PostRepository = PostRepository;
            _userService = userService;
            _CategoryRepository = categoryRepository;
        }

        public async Task<ApiResponse> Handle(CreateHeadingCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var user = await _userService.GetCurrentUser();

                // convert to domain entity object
                var Heading = _mapper.Map<Domain.Heading>(request);
                Heading.UserName = user.UserName;
                if (user.Id != null)
                {
                    Heading.UserId = new Guid(user.Id);
                }

                var category = await _CategoryRepository.GetByIdAsync(Heading.CategoryId);

                // add to database
                await _HeadingRepository.CreateAsync(Heading);

                if (request.Content != null)
                {
                    Domain.Post headingPost = new Domain.Post
                    {
                        HeadingId = Heading.Id,
                        Content = request.Content,
                        UserName = user.UserName,
                    };

                    if (user.Id != null)
                    {
                        headingPost.UserId = new Guid(user.Id);
                    }

                    await _PostRepository.CreateAsync(headingPost);

                    Heading.MainPostId = headingPost.Id;
                    Heading.LastPostId = headingPost.Id;

                    await _HeadingRepository.UpdateAsync(Heading);

                    await _HeadingRepository.UpdateHeadingWhenCreatePost(Heading.Id, headingPost.UserName, headingPost.UserId.Value, headingPost.Id);
                    await _CategoryRepository.UpdateCategoryWhenCreatePost(Heading.CategoryId, headingPost.UserName, headingPost.UserId.Value, Heading.Id, headingPost.Id);
                }
                else
                {
                    response.Message = "The content is cannot be null or empty";
                    response.IsSuccess = false;

                    return response;
                }

                if (Heading.Id != null && category != null)
                {
                    await _CategoryRepository.IncreaseHeadingCounter(Heading.CategoryId);
                    await _HeadingRepository.IncreasePostCounter(Heading.Id);
                    await _CategoryRepository.IncreasePostCounter(Heading.Id);
                    await _userService.IncreaseHeadingPostCounter(user.Id);
                }

                response.Message = "The heading is created successfully";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
