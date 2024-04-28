using Application.Contracts.Persistence;
using Application.Features.Post.Queries.GetPostsWithPagination;
using AutoMapper;
using MediatR;


namespace Application.Features.Heading.Queries.GetHeadingsWithPagination
{


    public class GetHeadingsWithPaginationQueryHandler : IRequestHandler<GetHeadingsWithPaginationQuery, HeadingsPaginationDTO>
    {
        private readonly IMapper _mapper;
        private readonly IHeadingRepository _headingRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetHeadingsWithPaginationQueryHandler(IMapper mapper, IHeadingRepository headingRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _headingRepository = headingRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<HeadingsPaginationDTO> Handle(GetHeadingsWithPaginationQuery request, CancellationToken cancellationToken)
        {

            List<Domain.Heading> headings;
            // query the database
            
            if (request.CategoryName != null)
            {
                var category = await _categoryRepository.GetByName(request.CategoryName);

                if (category != null)
                {
                    headings = await _headingRepository.GetHeadingsByCategoryIdWithPagination(category.Id, request.PageIndex!.Value, request.PageSize!.Value);

                    var data = _mapper.Map<List<HeadingDTO>>(headings);

                    HeadingsPaginationDTO dto = new HeadingsPaginationDTO
                    {
                        Headings = data,
                        TotalCount = _headingRepository.GetHeadingsCountByCategoryId(category.Id)
                    };
                    return dto;
                }
            }


            return new HeadingsPaginationDTO();
        }
    }
}
