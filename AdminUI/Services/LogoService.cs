using AdminUI.Contracts;
using AdminUI.Models;
using AdminUI.Models.Logo;
using AdminUI.Services.Base;
using AdminUI.Services.Common;
using AutoMapper;

namespace AdminUI.Services
{
    public class LogoService : BaseHttpService, ILogoService
    {
        private readonly IMapper _mapper;
        public LogoService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> AddLogo(AddLogoCommandVM command)
        {
            var addLogoCommand = _mapper.Map<AddLogoCommand>(command);
            var data = await _client.AddLogoAsync(addLogoCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<LogoVM> GetLogo()
        {
            var logo = await _client.GetLogoAsync();
            var data = _mapper.Map<LogoVM>(logo);

            return data;
        }

        public async Task<ApiResponseVM> RemoveLogo(RemoveLogoCommandVM command)
        {
            var removeLogoCommand = _mapper.Map<RemoveLogoCommand>(command);
            var data = await _client.RemoveLogoAsync(removeLogoCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ApiResponseVM> UpdateLogo(UpdateLogoCommandVM command)
        {
            var updateLogoCommand = _mapper.Map<UpdateLogoCommand>(command);
            var data = await _client.UpdateLogoAsync(updateLogoCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
