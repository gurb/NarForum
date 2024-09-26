using Application.Contracts.Identity;
using Application.Contracts.Persistence;
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
    public class CreateHeadingCommandHandler : IRequestHandler<CreateHeadingCommand, Guid>
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

        public async Task<Guid> Handle(CreateHeadingCommand request, CancellationToken cancellationToken)
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

                await _HeadingRepository.UpdateHeadingWhenCreatePost(Heading.Id, headingPost.UserName, headingPost.Id);
                await _CategoryRepository.UpdateCategoryWhenCreatePost(Heading.CategoryId, headingPost.UserName, Heading.Id, headingPost.Id);
            }

            if (Heading.Id != null && category != null)
            {
                await _CategoryRepository.IncreaseHeadingCounter(Heading.CategoryId);
                await _HeadingRepository.IncreasePostCounter(Heading.Id);
                await _CategoryRepository.IncreasePostCounter(Heading.Id);
            }

            // return record id
            return Heading.Id;
        }
    }
}
