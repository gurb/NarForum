using Application.Contracts.Persistence;
using Application.Features.Section.Queries.GetSections;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // convert data objecs to DTOs
            var data = _mapper.Map<List<CategoryDTO>>(categories);

            // return list of DTOs
            return data;
        }
    }
}
