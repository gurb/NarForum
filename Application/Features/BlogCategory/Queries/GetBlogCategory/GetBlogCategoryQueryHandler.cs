using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.BlogCategory.Queries.GetBlogCategories;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogCategory.Queries.GetBlogCategory
{
    public class GetBlogCategoryQueryHandler : IRequestHandler<GetBlogCategoryQuery, BlogCategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        public GetBlogCategoryQueryHandler(IMapper mapper, IBlogCategoryRepository blogCategoryRepository)
        {
            _mapper = mapper;
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task<BlogCategoryDTO> Handle(GetBlogCategoryQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.True<Domain.BlogCategory>();

            if (request.Id is not null)
            {
                predicate = predicate.And(x => x.Id == request.Id);
            }
            else
            {
                return null;
            }

            var blogCategories = await _blogCategoryRepository.GetAsync(predicate);

            var data = _mapper.Map<BlogCategoryDTO>(blogCategories);

            return data;
        }
    }
}
