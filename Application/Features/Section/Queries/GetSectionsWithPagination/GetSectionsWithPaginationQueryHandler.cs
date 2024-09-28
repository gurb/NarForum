using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Section.Queries.GetSections;
using AutoMapper;
using MediatR;

namespace Application.Features.Section.Queries.GetSectionsWithPagination
{

    public class GetSectionsWithPaginationQueryHandler : IRequestHandler<GetSectionsWithPaginationQuery, SectionsPaginationDTO>
    {
        private readonly IMapper _mapper;
        private readonly ISectionRepository _sectionRepository;

        public GetSectionsWithPaginationQueryHandler(IMapper mapper, ISectionRepository sectionRepository)
        {
            _mapper = mapper;
            _sectionRepository = sectionRepository;
        }

        public async Task<SectionsPaginationDTO> Handle(GetSectionsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Section> categories;
            // query the database

            var predicate = PredicateBuilder.True<Domain.Section>();

            predicate = predicate.And(x => x.IsActive);

            categories = await _sectionRepository.GetWithPagination(predicate, request.PageIndex!.Value, request.PageSize!.Value);
            var data = _mapper.Map<List<SectionDTO>>(categories);

            SectionsPaginationDTO dto = new SectionsPaginationDTO
            {
                Sections = data,
                TotalCount = _sectionRepository.GetCount(predicate)
            };
            return dto;
        }
    }
}
