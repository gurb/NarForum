using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ForumSetting.Commands.UpdateForumSettings
{
    public class UpdateForumSettingsCommandHandler : IRequestHandler<UpdateForumSettingsCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForumSettingsService _settingsService;

        public UpdateForumSettingsCommandHandler(IMapper mapper, IForumSettingsService settingsService)
        {
            _mapper = mapper;
            _settingsService = settingsService;
        }
        public async Task<ApiResponse> Handle(UpdateForumSettingsCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var settings = await _settingsService.GetAsync();

                if(settings is null)
                {
                    var data = new Domain.ForumSettings
                    {
                        ForumUrl = request.ForumUrl,
                        IsShowConsentCookie = request.IsShowConsentCookie,
                    };
                    await _settingsService.AddAsync(data);
                }
                else
                {
                    var data = _mapper.Map<Domain.ForumSettings>(request);
                    await _settingsService.UpdateAsync(data);
                }
                response.Message = "Forum settings is saved";
            }
            catch (Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
