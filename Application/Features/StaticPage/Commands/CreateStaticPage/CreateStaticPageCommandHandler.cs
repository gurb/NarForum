using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.StaticPage.Commands.CreateStaticPage;

public class CreateStaticPageCommandHandler : IRequestHandler<CreateStaticPageCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;
    private readonly IUserService _userService;
    public CreateStaticPageCommandHandler(IMapper mapper, IPageRepository pageRepository, IUserService userService)
    {
        _mapper = mapper;
        _pageRepository = pageRepository;
        _userService = userService;
    }

    public async Task<ApiResponse> Handle(CreateStaticPageCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            var anyUrl = _pageRepository.GetStaticPageByUrl(request.Url);
            if (anyUrl != null) 
            {
                response.IsSuccess = false;
                response.Message = "There is already defined this url for another page";
                return response;
            }

            var staticPage = _mapper.Map<Domain.StaticPage>(request);
            staticPage.IsDraft = true;

            var user = await _userService.GetCurrentUser();
            if (user.Id != null)
            {
                staticPage.Author = user.UserName;
                staticPage.UserId = new Guid(user.Id);
            }

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
