using Application.Contracts.Persistence;
using Application.Extensions.Core;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogCategory.Queries.GetBlogCategories;

public class GetBlogCategoriesQueryHandler : IRequestHandler<GetBlogCategoriesQuery, List<BlogCategoryDTO>>
{
    private readonly IMapper _mapper;
    private readonly IBlogCategoryRepository _blogCategoryRepository;

    public GetBlogCategoriesQueryHandler(IMapper mapper, IBlogCategoryRepository blogCategoryRepository)
    {
        _mapper = mapper;
        _blogCategoryRepository = blogCategoryRepository;
    }

    public async Task<List<BlogCategoryDTO>> Handle(GetBlogCategoriesQuery request, CancellationToken cancellationToken)
    {

        var predicate = PredicateBuilder.True<Domain.BlogCategory>();

        if (!String.IsNullOrEmpty(request.SearchText))
        {
            predicate = predicate.And(x => x.Name.ToLower().Contains(request.SearchText.ToLower()));
        }

        var blogCategories = await _blogCategoryRepository.GetAllAsync(predicate);

        var data = _mapper.Map<List<BlogCategoryDTO>>(blogCategories);

        return data;
    }
}
