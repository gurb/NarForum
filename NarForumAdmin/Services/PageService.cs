using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.StaticPage;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
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
            try
            {
                var createStaticPage = _mapper.Map<CreateStaticPageCommand>(command);
                var data = await _client.CreateStaticPageAsync(createStaticPage);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> DraftStaticPage(DraftStaticPageCommandVM command)
        {
            try
            {
                var draftStaticPage = _mapper.Map<DraftStaticPageCommand>(command);
                var data = await _client.DraftStaticPageAsync(draftStaticPage);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<StaticPageVM> GetStaticPage(GetStaticPageQueryVM request)
        {
            try
            {
                var query = _mapper.Map<GetStaticPageQuery>(request);
                var data = await _client.GetStaticPageAsync(query);

                return _mapper.Map<StaticPageVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<StaticPageVM>> GetStaticPages(GetStaticPagesQueryVM request)
        {
            try
            {
                var query = _mapper.Map<GetStaticPagesQuery>(request);
                var data = await _client.GetStaticPagesAsync(query);

                return _mapper.Map<List<StaticPageVM>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        

        public async Task<StaticPagesPaginationVM> GetStaticPagesWithPagination(GetStaticPagesWithPaginationQueryVM request)
        {
            try
            {
                GetStaticPagesWithPaginationQuery query = _mapper.Map<GetStaticPagesWithPaginationQuery>(request);

                var staticPagesPagination = await _client.GetStaticPagesWithPaginationAsync(query);

                var data = _mapper.Map<StaticPagesPaginationVM>(staticPagesPagination);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> PublishStaticPage(PublishStaticPageCommandVM command)
        {
            try
            {
                var publishStaticPageCommand = _mapper.Map<PublishStaticPageCommand>(command);
                var data = await _client.PublishStaticPageAsync(publishStaticPageCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> RemoveStaticPage(RemoveStaticPageCommandVM command)
        {
            try
            {
                var removeStaticPageCommand = _mapper.Map<RemoveStaticPageCommand>(command);
                var data = await _client.RemoveStaticPageAsync(removeStaticPageCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdateStaticPage(UpdateStaticPageCommandVM command)
        {
            try
            {
                var updateStaticPageCommand = _mapper.Map<UpdateStaticPageCommand>(command);
                var data = await _client.UpdateStaticPageAsync(updateStaticPageCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
