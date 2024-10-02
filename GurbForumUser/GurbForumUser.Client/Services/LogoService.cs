using AutoMapper;
using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models.Logo;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;

namespace GurbForumUser.Client.Services
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
