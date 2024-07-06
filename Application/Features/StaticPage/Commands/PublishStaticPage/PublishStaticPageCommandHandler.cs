using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.StaticPage.Commands.PublishStaticPage
{
    public class PublishStaticPageCommandHandler: IRequestHandler<PublishStaticPageCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPageRepository _pageRepository;

        public PublishStaticPageCommandHandler(IMapper mapper, IPageRepository pageRepository)
        {
            _mapper = mapper;
            _pageRepository = pageRepository;
        }

        public async Task<ApiResponse> Handle(PublishStaticPageCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var staticPage = await _pageRepository.GetByIdAsync(request.Id);

                if (staticPage != null)
                {
                    staticPage.IsPublished = true;
                    staticPage.IsDraft = false;

                    await _pageRepository.UpdateAsync(staticPage);

                    response.Message = "static page is published";
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
