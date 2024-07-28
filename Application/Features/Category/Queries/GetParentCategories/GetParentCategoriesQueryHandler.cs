using Application.Contracts.Persistence;
using Application.Features.Category.Queries.GetCategories;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetParentCategories
{
    public class GetParentCategoriesQueryHandler : IRequestHandler<GetParentCategoriesQuery, List<CategoryDTO>>
    {

        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetParentCategoriesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDTO>> Handle(GetParentCategoriesQuery request, CancellationToken cancellationToken)
        {
            // query the database
            var categories = await _categoryRepository.GetAsync();

            var childCategory = categories.FirstOrDefault(x => x.Name == request.CategoryName);

            List<Domain.Category> response = new List<Domain.Category>();

            if (categories != null && childCategory != null)
            {
                response.Add(childCategory);

                if (categories.Count > 0)
                {
                    var list = GetParentsOfCategory(childCategory, categories, response);
                    var data = _mapper.Map<List<CategoryDTO>>(list);

                    return data;
                }
            }

            return new List<CategoryDTO>() { };
        }

        private List<Domain.Category> GetParentsOfCategory(Domain.Category child, List<Domain.Category> list, List<Domain.Category> response)
        {
            if (child.ParentCategoryId == Guid.Empty)
            {
                return response;
            }
            else
            {
                var parentCategory = list.FirstOrDefault(x => x.Id == child.ParentCategoryId);
                if (parentCategory != null)
                {
                    response.Add(parentCategory);

                    return GetParentsOfCategory(parentCategory, list, response);
                }
                else
                {
                    return response;
                }
            }
        }

    }
}
