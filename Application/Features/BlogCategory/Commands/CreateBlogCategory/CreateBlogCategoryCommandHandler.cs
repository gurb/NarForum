using Application.Contracts.Persistence;
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
