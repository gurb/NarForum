using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Heading.Queries.GetHeadings
{
    public class GetHeadingsQueryHandler : IRequestHandler<GetHeadingsQuery, List<HeadingDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IHeadingRepository _headingRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetHeadingsQueryHandler(IMapper mapper, IHeadingRepository headingRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _headingRepository = headingRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<HeadingDTO>> Handle(GetHeadingsQuery request, CancellationToken cancellationToken)
        {
            // query the database
            var headings = await _headingRepository.GetAsync();
            Domain.Category? category = null;

            if (request.CategoryId != null)
            {
                category = await _categoryRepository.GetByIdAsync(request.CategoryId.Value);

                headings = headings.Where(x => x.CategoryId == request.CategoryId).ToList();
            }

            if (request.CategoryName != null)
            {
                category = await _categoryRepository.GetByName(request.CategoryName);

                if (category != null)
                {
                    headings = headings.Where(x => x.CategoryId == category.Id).ToList();
                }
            }


            // convert data objecs to DTOs
            var data = _mapper.Map<List<HeadingDTO>>(headings);

            if (category != null)
            {
                foreach (var item in data)
                {
                    item.CategoryIntId = category.CategoryId;
                }
            }

            // return list of DTOs
            return data;
        }
    }
}
