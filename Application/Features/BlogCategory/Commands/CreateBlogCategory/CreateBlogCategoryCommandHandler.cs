using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.BlogCategory.Commands.CreateBlogCategory;

public class CreateBlogCategoryCommandHandler : IRequestHandler<CreateBlogCategoryCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IBlogCategoryRepository _blogCategoryRepository;

    public CreateBlogCategoryCommandHandler(IMapper mapper, IBlogCategoryRepository blogCategoryRepository)
    {
        _mapper = mapper;
        _blogCategoryRepository = blogCategoryRepository;
    }

    public async Task<ApiResponse> Handle(CreateBlogCategoryCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var predicate = PredicateBuilder.True<Domain.BlogCategory>();

            predicate = predicate.And(x => x.Name == request.Name);

            var exist = await _blogCategoryRepository.AnyAsync(predicate);

            if(exist)
            {
                response.IsSuccess = false;
                response.Message = "Already exist";

                return response;
            }

            var blogCategory = _mapper.Map<Domain.BlogCategory>(request);

            await _blogCategoryRepository.AddAsync(blogCategory);

            response.Message = "Blog category is added.";
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }

        return response;
    }
}
