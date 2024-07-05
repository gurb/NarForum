using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.StaticPage.Commands.UpdateStaticPage;

public class UpdateStaticPageCommandHandler: IRequestHandler<UpdateStaticPageCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;
    public UpdateStaticPageCommandHandler(IMapper mapper, IPageRepository pageRepository)
    {
        _mapper = mapper;
        _pageRepository = pageRepository;
    }

    public async Task<ApiResponse> Handle(UpdateStaticPageCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var staticPage = await _pageRepository.GetByIdAsync(request.Id, true);

            if (staticPage != null)
            {
                staticPage.Url = request.Url;
                staticPage.Content = request.Content;
                staticPage.Title = request.Title;

                await _pageRepository.UpdateAsync(staticPage);
                response.Message = "Static page is updated.";
            }
            else
            {
                response.Message = "Static page not found";
                response.IsSuccess = false;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
        }

        return response;
    }
}
