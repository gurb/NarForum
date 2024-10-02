using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.StaticPage;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;
using AutoMapper;

namespace GurbForumUser.Client.Services
{
    public class PageService : BaseHttpService, IPageService
    {
        private readonly IMapper _mapper;

        public PageService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> CreateStaticPage(CreateStaticPageCommandVM command)
        {
            var createStaticPage = _mapper.Map<CreateStaticPageCommand>(command);
            var data = await _client.CreateStaticPageAsync(createStaticPage);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ApiResponseVM> DraftStaticPage(DraftStaticPageCommandVM command)
        {
            var draftStaticPage = _mapper.Map<DraftStaticPageCommand>(command);
            var data = await _client.DraftStaticPageAsync(draftStaticPage);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<StaticPageVM> GetStaticPage(GetStaticPageQueryVM request)
        {
            var query = _mapper.Map<GetStaticPageQuery>(request);
            var data = await _client.GetStaticPageAsync(query);

            return _mapper.Map<StaticPageVM>(data);
        }

        public async Task<List<StaticPageVM>> GetStaticPages(GetStaticPagesQueryVM request)
        {
            var query = _mapper.Map<GetStaticPagesQuery>(request);
            var data = await _client.GetStaticPagesAsync(query);

            return _mapper.Map<List<StaticPageVM>>(data);
        }

        

        public async Task<StaticPagesPaginationVM> GetStaticPagesWithPagination(GetStaticPagesWithPaginationQueryVM request)
        {
            GetStaticPagesWithPaginationQuery query = _mapper.Map<GetStaticPagesWithPaginationQuery>(request);

            var staticPagesPagination = await _client.GetStaticPagesWithPaginationAsync(query);

            var data = _mapper.Map<StaticPagesPaginationVM>(staticPagesPagination);

            return data;
        }

        public async Task<ApiResponseVM> PublishStaticPage(PublishStaticPageCommandVM command)
        {
            var publishStaticPageCommand = _mapper.Map<PublishStaticPageCommand>(command);
            var data = await _client.PublishStaticPageAsync(publishStaticPageCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ApiResponseVM> RemoveStaticPage(RemoveStaticPageCommandVM command)
        {
            var removeStaticPageCommand = _mapper.Map<RemoveStaticPageCommand>(command);
            var data = await _client.RemoveStaticPageAsync(removeStaticPageCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ApiResponseVM> UpdateStaticPage(UpdateStaticPageCommandVM command)
        {
            var updateStaticPageCommand = _mapper.Map<UpdateStaticPageCommand>(command);
            var data = await _client.UpdateStaticPageAsync(updateStaticPageCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
