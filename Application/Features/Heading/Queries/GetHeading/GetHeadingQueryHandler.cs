using Application.Contracts.Persistence;
using Application.Features.Heading.Queries.GetHeadings;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Heading.Queries.GetHeading
{
    public class GetHeadingQueryHandler : IRequestHandler<GetHeadingQuery, HeadingDTO>
    {
        private readonly IMapper _mapper;
        private readonly IHeadingRepository _headingRepository;

        public GetHeadingQueryHandler(IMapper mapper, IHeadingRepository headingRepository)
        {
            _mapper = mapper;
            _headingRepository = headingRepository;
        }

        public async Task<HeadingDTO> Handle(GetHeadingQuery request, CancellationToken cancellationToken)
        {
            // query the database
            var heading = await _headingRepository.GetHeadingById(request.HeadingId);

            // convert data objecs to DTOs
            var data = _mapper.Map<HeadingDTO>(heading);

            // return list of DTOs
            return data;
        }
    }
}
