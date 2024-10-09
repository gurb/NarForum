using Application.Contracts.Persistence;
using Application.Extensions.Core;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Category.Commands.RemoveCategory
{
    
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHeadingRepository _headingRepository;
        private readonly IPostRepository _postRepository;

        public RemoveCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IHeadingRepository headingRepository, IPostRepository postRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _headingRepository = headingRepository;
            _postRepository = postRepository;
        }

        public async Task<Guid> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            if(request.CategoryId == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                var category = await _categoryRepository.GetByIdAsyncWithTrack(request.CategoryId!);

                if(category != null)
                {
                    category.IsActive = !category.IsActive;
                    await _categoryRepository.UpdateAsync(category);
                    await UpdateCategoryIsActive(category);
                    return category.Id;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return Guid.Empty;
        }

        private async Task UpdateCategoryIsActive (Domain.Category category)
        {
            var predicate = PredicateBuilder.True<Domain.Category>();

            predicate = predicate.And(x => x.ParentCategoryId == category.Id);

            var childrenOfCategory = await _categoryRepository.GetAllAsync(predicate, true);

            foreach (var child in childrenOfCategory) 
            {
                child.IsActive = category.IsActive;
                await UpdateCategoryIsActive(child);    
            }
            _categoryRepository.UpdateList(childrenOfCategory);

            var predicateHeading = PredicateBuilder.True<Domain.Heading>();

            predicateHeading = predicateHeading.And(x => x.CategoryId == category.Id);

            var headingsOfCategory = await _headingRepository.GetAllAsync(predicateHeading, true);

            foreach (var child in headingsOfCategory)
            {
                child.IsActive = category.IsActive;
                await UpdateHeadingIsActive(child);
            }
            _headingRepository.UpdateList(headingsOfCategory);
        }

        private async Task UpdateHeadingIsActive (Domain.Heading heading)
        {
            var predicatePost = PredicateBuilder.True<Domain.Post>();

            predicatePost = predicatePost.And(x => x.HeadingId == heading.Id);

            var postsOfHeading = await _postRepository.GetAllAsync(predicatePost, true);
            foreach (var child in postsOfHeading)
            {
                child.IsActive = heading.IsActive;
            }
            _postRepository.UpdateList(postsOfHeading);
        }
    }
}
