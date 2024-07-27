using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Post.Queries.GetPostsWithPagination;
using AutoMapper;
using MediatR;
using System.Collections;


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

            var predicate = PredicateBuilder.True<Domain.Heading>();

            if(!String.IsNullOrEmpty(request.CategoryName))
            {
                var category = await _categoryRepository.GetByName(request.CategoryName);

                if (category != null)
                {
                    predicate = predicate.And(x => x.CategoryId == category.Id);
                }

            }

            if(!String.IsNullOrEmpty(request.UserName))
            {
                predicate = predicate.And(x => x.UserName == request.UserName);
            }

            headings = await _headingRepository.GetWithPagination(predicate, request.PageIndex!.Value, request.PageSize!.Value);
            var data = _mapper.Map<List<HeadingDTO>>(headings);

            List<string?> categoryIds = headings.Select(x => x.CategoryId).ToList();
            List<Domain.Category> categories = await _categoryRepository.GetAllAsync(x => categoryIds.Contains(x.Id));

            foreach (var heading in data)
            {
                var category = categories.FirstOrDefault(x => x.Id == heading.CategoryId);
                if (category != null)
                {
                    heading.CategoryName = category.Name;
                }
            }

            HeadingsPaginationDTO dto = new HeadingsPaginationDTO
            {
                Headings = data,
                TotalCount = _headingRepository.GetCount(predicate)
            };
            return dto;
        }
    }
}
