using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.Logo;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
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
            try
            {
                var addLogoCommand = _mapper.Map<AddLogoCommand>(command);
                var data = await _client.AddLogoAsync(addLogoCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<LogoVM> GetLogo()
        {
            try
            {
                var logo = await _client.GetLogoAsync();
                var data = _mapper.Map<LogoVM>(logo);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> RemoveLogo(RemoveLogoCommandVM command)
        {
            try
            {
                var removeLogoCommand = _mapper.Map<RemoveLogoCommand>(command);
                var data = await _client.RemoveLogoAsync(removeLogoCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdateLogo(UpdateLogoCommandVM command)
        {
            try
            {
                var updateLogoCommand = _mapper.Map<UpdateLogoCommand>(command);
                var data = await _client.UpdateLogoAsync(updateLogoCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
