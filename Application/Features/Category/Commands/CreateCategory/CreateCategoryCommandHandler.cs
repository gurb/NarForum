using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            ApiResponse response = new();
            // validate incoming data
            //var validator = new CreatePostCommandValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //if (validationResult.Errors.Any())
            //{
            //    throw new BadRequestException("Invalid Post", validationResult);
            //}

            // convert to domain entity object
            try
            {
                var category = _mapper.Map<Domain.Category>(request);

                var categoryExist = await _categoryRepository.GetByName(category.Name);

                if (categoryExist is not null && request.SectionId == categoryExist.SectionId)
                {
                    response.IsSuccess = false;
                    response.Message = "Category name is already exist";
                    return response;
				}

                // add to database
                await _categoryRepository.CreateAsync(category);
                response.Message = "Category is added";

                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;

            // return record id
        }
    }
}
