using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ForumSetting.Queries.GetForumSettings
{
    public class GetForumSettingsQueryHandler : IRequestHandler<GetForumSettingsQuery, ForumSettingsDTO>
    {

        private readonly IMapper _mapper;
        private readonly IForumSettingsService _settingsService;

        public GetForumSettingsQueryHandler(IMapper mapper, IForumSettingsService settingsService)
        {
            _mapper = mapper;
            _settingsService = settingsService;
        }

        public async Task<ForumSettingsDTO> Handle(GetForumSettingsQuery request, CancellationToken cancellationToken)
        {
            var data = await _settingsService.GetAsync();

            if(data != null)
            {
                return _mapper.Map<ForumSettingsDTO>(data);
            }
            else
            {
                return new ForumSettingsDTO();
            }
        }
    }
}
