using Application.Contracts.Persistence;
using Application.Models;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory
{
    
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ApiResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new();
            
            try
            {
                if(request.Id != null)
                {
                    var updateCategory = await _categoryRepository.GetByIdAsync(request.Id.Value, true);


                    if(updateCategory != null)
                    {
                        updateCategory.Name = request.Name;
                        updateCategory.Description = request.Description;

                        await _categoryRepository.UpdateAsync(updateCategory);

                        response.Message = "Category is updated";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Category is not found";
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Category id is null";
                }

                // add to database

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
