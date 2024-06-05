﻿using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.RemoveCategory
{
    
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public RemoveCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            if(request.CategoryId == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                var category = await _categoryRepository.GetByIdAsyncWithTrack(request.CategoryId!.Value);

                if(category != null)
                {
                    category.IsActive = !category.IsActive;
                    await _categoryRepository.UpdateAsync(category);
                    return category.Id;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return 0;

            // return record id
        }
    }
}