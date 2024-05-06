using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Favorite.Commands.AddFavorite
{
    
    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public AddFavoriteCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
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

                // add to database
                await _categoryRepository.CreateAsync(category);

                return category.Id;

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
