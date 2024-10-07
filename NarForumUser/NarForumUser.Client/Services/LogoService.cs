using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models.Logo;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;

namespace NarForumUser.Client.Services
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
