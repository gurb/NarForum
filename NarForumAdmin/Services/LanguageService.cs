using AutoMapper;
using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;

namespace NarForumAdmin.Services
{
    public class LanguageService: BaseHttpService, ILanguageService
    {
        private readonly IMapper _mapper;
        public LanguageService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> ChangeLanguage(string lang, string jsonStr)
        {
            try
            {
                var response = await _client.ChangeLanguageAsync(lang, jsonStr);

                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                return new ApiResponseVM
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}
