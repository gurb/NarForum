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


            if (request.CategoryId != null)
            {
                headings = headings.Where(x => x.CategoryId == request.CategoryId).ToList();
            }

            if (request.CategoryName != null)
            {
                var category = await _categoryRepository.GetByName(request.CategoryName);

                if (category != null)
                {
                    headings = headings.Where(x => x.CategoryId == category.Id).ToList();
                }
            }

            // convert data objecs to DTOs
            var data = _mapper.Map<List<HeadingDTO>>(headings);

            // return list of DTOs
            return data;
        }
    }
}
