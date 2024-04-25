using Application.Contracts.Persistence;
using Application.Features.Category.Queries.GetCategories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Heading.Queries.GetHeadings
{
    public class GetHeadingsQueryHandler : IRequestHandler<GetHeadingsQuery, List<HeadingDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IHeadingRepository _headingRepository;

        public GetHeadingsQueryHandler(IMapper mapper, IHeadingRepository headingRepository)
        {
            _mapper = mapper;
            _headingRepository = headingRepository;
        }

        public async Task<List<HeadingDTO>> Handle(GetHeadingsQuery request, CancellationToken cancellationToken)
        {
            // query the database
            var categories = await _headingRepository.GetAsync();

            // convert data objecs to DTOs
            var data = _mapper.Map<List<HeadingDTO>>(categories);

            // return list of DTOs
            return data;
        }
    }
}
