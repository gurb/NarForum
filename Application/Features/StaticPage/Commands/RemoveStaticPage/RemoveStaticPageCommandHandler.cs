using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StaticPage.Commands.RemoveStaticPage;

public class RemoveStaticPageCommandHandler : IRequestHandler<RemoveStaticPageCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;

    public RemoveStaticPageCommandHandler(IMapper mapper, IPageRepository pageRepository)
    {
        _mapper = mapper;
        _pageRepository = pageRepository;
    }

    public async Task<ApiResponse> Handle(RemoveStaticPageCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var staticPage = await _pageRepository.GetByIdAsync(request.Id, true);

            if(staticPage != null)
            {
                staticPage.IsActive = !staticPage.IsActive;
                await _pageRepository.UpdateAsync(staticPage);
                response.Message = "Static page is removed.";
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
