using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;


namespace Application.Features.Category.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHeadingRepository _headingRepository;

        public GetCategoriesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, IHeadingRepository headingRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _headingRepository = headingRepository;
        }

        public async Task<List<CategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            // query the database
            var categories = await _categoryRepository.GetAsync();
            var categorieLastHeadingIds = categories.Select(x => x.LastHeadingId).ToList();

            var headings = await _headingRepository.GetAllAsync(x => categorieLastHeadingIds.Contains(x.Id));


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

            if(request.IsOnlySection != null && request.IsOnlySection == true)
            {
                categories = categories.Where(x => x.ParentCategoryId == Guid.Empty).ToList();
            }

            // convert data objecs to DTOs
            var data = _mapper.Map<List<CategoryDTO>>(categories);

            foreach (var category in data) 
            {
                var heading = headings.FirstOrDefault(x => x.Id == category.LastHeadingId);
                
                if(heading != null)
                {
                    category.LastHeadingTitle = heading.Title;
                }
            }

            // return list of DTOs
            return data;
        }
    }
}
