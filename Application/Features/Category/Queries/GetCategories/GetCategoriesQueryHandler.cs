using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;


namespace Application.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            // query the database
            var categories = await _categoryRepository.GetAsync();


            if(request.ParentCategoryId != null)
            {
                categories = categories.Where(x => x.ParentCategoryId == request.ParentCategoryId).ToList();
            }

            if(request.CategoryName != null)
            {
                var parentCategory = categories.FirstOrDefault(x => x.Name == request.CategoryName);

                if(parentCategory != null)
                {
                    categories = categories.Where(x => x.ParentCategoryId == parentCategory.Id).ToList();
                }
            }

            // convert data objecs to DTOs
            var data = _mapper.Map<List<CategoryDTO>>(categories);

            // return list of DTOs
            return data;
        }
    }
}
