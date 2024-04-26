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
            if(request.CategoryName == null)
            {
                throw new Exception("CategoryName can not be null");
            }

            // query the database
            var category = await _categoryRepository.GetByName(request.CategoryName);

            // convert data objecs to DTOs
            var data = _mapper.Map<CategoryDTO>(category);

            // return list of DTOs
            return data;
        }
    }
}
