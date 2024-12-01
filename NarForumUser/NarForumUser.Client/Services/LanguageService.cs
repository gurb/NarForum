using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;

namespace NarForumUser.Client.Services
{
    public class LanguageService: BaseHttpService, ILanguageService
    {
        private readonly IMapper _mapper;
        public LanguageService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

       
    }
}
