using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.StaticPage.Commands.CreateStaticPage;

public class CreateStaticPageCommandHandler : IRequestHandler<CreateStaticPageCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;
    public CreateStaticPageCommandHandler(IMapper mapper, IPageRepository pageRepository)
    {
        _mapper = mapper;
        _pageRepository = pageRepository;
    }

    public async Task<ApiResponse> Handle(CreateStaticPageCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var staticPage = _mapper.Map<Domain.StaticPage>(request);

            await _pageRepository.CreateAsync(staticPage);

            response.Message = "Static page is created.";
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }

        return response;
    }
}
