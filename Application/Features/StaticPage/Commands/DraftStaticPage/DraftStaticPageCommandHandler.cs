using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.StaticPage.Commands.DraftStaticPage
{
    public class DraftStaticPageCommandHandler : IRequestHandler<DraftStaticPageCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPageRepository _pageRepository;

        public DraftStaticPageCommandHandler(IMapper mapper, IPageRepository pageRepository)
        {
            _mapper = mapper;
            _pageRepository = pageRepository;
        }

        public async Task<ApiResponse> Handle(DraftStaticPageCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var staticPage = await _pageRepository.GetByIdAsync(request.Id);

                if (staticPage != null)
                {
                    staticPage.IsDraft = true;
                    staticPage.IsPublished = false;

                    await _pageRepository.UpdateAsync(staticPage);

                    response.Message = "static page is draft";
                }
                else
                {
                    response.Message = "not found";
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
}
