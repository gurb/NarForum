using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Category.Queries.GetCategories;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoriesWithPagination
{
    public class GetCategoriesPaginationQueryHandler : IRequestHandler<GetCategoriesWithPaginationQuery, CategoriesPaginationDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesPaginationQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoriesPaginationDTO> Handle(GetCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Category> categories;
            // query the database

            var predicate = PredicateBuilder.True<Domain.Category>();

            predicate = predicate.And(x => x.IsActive);

            if(!String.IsNullOrEmpty(request.Name))
            {
                predicate = predicate.And(x => x.Name.ToLower().Contains(request.Name.ToLower()));
            }

            categories = await _categoryRepository.GetWithPagination(predicate, request.PageIndex!.Value, request.PageSize!.Value);
            var data = _mapper.Map<List<CategoryDTO>>(categories);

            CategoriesPaginationDTO dto = new CategoriesPaginationDTO
            {
                Categories = data,
                TotalCount = _categoryRepository.GetCount(predicate)
            };
            return dto;
        }
    }
}
