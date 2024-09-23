using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Post.Queries.GetPostsWithPagination;
using AutoMapper;
using Domain;
using MediatR;
using System.Collections;


namespace Application.Features.Heading.Queries.GetHeadingsWithPagination
{
    public class GetHeadingsWithPaginationQueryHandler : IRequestHandler<GetHeadingsWithPaginationQuery, HeadingsPaginationDTO>
    {
        private readonly IMapper _mapper;
        private readonly IHeadingRepository _headingRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserService _userService;

        public GetHeadingsWithPaginationQueryHandler(IMapper mapper, IHeadingRepository headingRepository, ICategoryRepository categoryRepository, IUserService userService)
        {
            _mapper = mapper;
            _headingRepository = headingRepository;
            _categoryRepository = categoryRepository;
            _userService = userService;
        }

        public async Task<HeadingsPaginationDTO> Handle(GetHeadingsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Heading> headings;
            // query the database

            var predicate = PredicateBuilder.True<Domain.Heading>();

            if(request.CategoryId is not null)
            {
				predicate = predicate.And(x => x.CategoryId == request.CategoryId);
			}

            if(!String.IsNullOrEmpty(request.CategoryName))
            {
                var category = await _categoryRepository.GetByName(request.CategoryName);

                if (category != null)
                {
                    predicate = predicate.And(x => x.CategoryId == category.Id);
                }
            }

            string? orderProperty = null;
            bool desc = true;

            if(!String.IsNullOrEmpty(request.UserName))
            {
                predicate = predicate.And(x => x.UserName == request.UserName);
            }

            if(!String.IsNullOrEmpty(request.SearchUser))
            {
                predicate = predicate.And(x => x.UserName.ToLower().Contains(request.SearchUser.ToLower()));
            }
            if (!String.IsNullOrEmpty(request.SearchTitle))
            {
                predicate = predicate.And(x => x.Title.ToLower().Contains(request.SearchTitle.ToLower()));
            }
            if (request.StartDate != null)
            {
                predicate = predicate.And(x => x.DateCreate.Value >= request.StartDate);
            }
            if (request.EndDate != null)
            {
                predicate = predicate.And(x => x.DateCreate.Value <= request.EndDate);
            }

            if (request.SortType == Models.Enums.SortType.RECENT)
            {
                orderProperty = "DateCreate";
                desc = true;
            }
            else if (request.SortType == Models.Enums.SortType.MOSTREPLIED)
            {
                orderProperty = "PostCounter";
                desc = true;
            }
            else if (request.SortType == Models.Enums.SortType.OLDEST)
            {
                orderProperty = "DateCreate";
                desc = false;
            }

            headings = await _headingRepository.GetWithPagination(predicate, request.PageIndex!.Value, request.PageSize!.Value, orderProperty, desc);
            var data = _mapper.Map<List<HeadingDTO>>(headings);


            List<Guid> categoryIds = headings.Select(x => x.CategoryId).ToList();
            List<Domain.Category> categories = await _categoryRepository.GetAllAsync(x => categoryIds.Contains(x.Id));

            foreach (var heading in data)
            {
                var category = categories.FirstOrDefault(x => x.Id == heading.CategoryId);
                if (category != null)
                {
                    heading.CategoryName = category.Name;
                    heading.CategoryIntId = category.CategoryId;
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
