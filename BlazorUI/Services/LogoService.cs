using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models.Logo;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services
{
    public class LogoService : BaseHttpService, ILogoService
    {
        private readonly IMapper _mapper;
        public LogoService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }
        public async Task<LogoVM> GetLogo()
        {
            var logo = await _client.GetLogoAsync();
            var data = _mapper.Map<LogoVM>(logo);

            return data;
        }
    }
}
