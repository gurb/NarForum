using Application.Contracts.Persistence;
using Application.Features.Category.Queries.GetCategories;
using AutoMapper;
using MediatR;


namespace Application.Features.Category.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDTO> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            CategoryDTO categoryDTO = new CategoryDTO();

            Domain.Category? category = null;

            if (request.CategoryId != null)
            {
                category = await _categoryRepository.GetByIntId(request.CategoryId.Value);
            }
            else if (request.CategoryName != null)
            {
                category = await _categoryRepository.GetByName(request.CategoryName);
            }

            if(category != null)
            {
                categoryDTO = _mapper.Map<CategoryDTO>(category);
            }

            // return list of DTOs
            return categoryDTO;
        }
    }
}
