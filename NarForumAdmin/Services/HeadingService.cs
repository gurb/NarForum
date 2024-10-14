using AutoMapper;
using NarForumAdmin.Contracts;
using NarForumAdmin.Models.Heading;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using NarForumAdmin.Models;
using NarForumAdmin.Models.Stat;

namespace NarForumAdmin.Services
{
    public class HeadingService : BaseHttpService, IHeadingService
    {
        private readonly IMapper _mapper;
        public HeadingService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> CreateHeading(HeadingVM post)
        {
            try
            {
                var createHeadingCommand = _mapper.Map<CreateHeadingCommand>(post);
                var response = await _client.HeadingsAsync(createHeadingCommand);
                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (ApiException ex)
            {
                return new ApiResponseVM
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<HeadingVM> GetHeadingById(Guid id)
        {
            
            try
            {
                var heading = await _client.GetHeadingByIdAsync(id);
                var data = _mapper.Map<HeadingVM>(heading);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<HeadingVM>> GetHeadings()
        {
            try
            {
                var headings = await _client.HeadingsAllAsync();
                var data = _mapper.Map<List<HeadingVM>>(headings);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<HeadingVM>> GetHeadingsByCategoryId(Guid categoryId)
        {
            try
            {
                var headings = await _client.GetHeadingsByCategoryIdAsync(categoryId);
                var data = _mapper.Map<List<HeadingVM>>(headings);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<HeadingVM>> GetHeadingsByCategoryName(string name)
        {
            try
            {
                var headings = await _client.GetHeadingsByCategoryNameAsync(name);
                var data = _mapper.Map<List<HeadingVM>>(headings);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<HeadingsPaginationVM> GetHeadingsByCategoryIdWithPagination(Guid categoryId, int pageIndex, int pageSize)
        {
            try
            {
                var headingsPagination = await _client.GetHeadingsByCategoryIdWithPaginationAsync(categoryId, pageIndex, pageSize);

                var data = _mapper.Map<HeadingsPaginationVM>(headingsPagination);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<HeadingsPaginationVM> GetHeadingsByUserNameWithPagination(string userName, int pageIndex, int pageSize)
        {
            try
            {
                var headingsPagination = await _client.GetHeadingsByUserNameWithPaginationAsync(userName, pageIndex, pageSize);

                var data = _mapper.Map<HeadingsPaginationVM>(headingsPagination);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<HeadingsPaginationVM> GetHeadingsWithPagination(HeadingPaginationQueryVM paramQuery)
        {
            try
            {
                GetHeadingsWithPaginationQuery query = _mapper.Map<GetHeadingsWithPaginationQuery>(paramQuery);

                var headingsPagination = await _client.GetHeadingsWithPaginationAsync(query);

                var data = _mapper.Map<HeadingsPaginationVM>(headingsPagination);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task RemoveHeading(RemoveHeadingCommandVM heading)
        {
            try
            {
                RemoveHeadingCommand command = _mapper.Map<RemoveHeadingCommand>(heading);
                await _client.RemoveHeadingAsync(command);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> LockHeading(LockHeadingCommandVM command)
        {
            try
            {
                LockHeadingCommand lockCommand = _mapper.Map<LockHeadingCommand>(command);
                var response = await _client.LockHeadingAsync(lockCommand);
                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> PinHeading(PinHeadingCommandVM command)
        {
            try
            {
                PinHeadingCommand pinCommand = _mapper.Map<PinHeadingCommand>(command);
                var response = await _client.PinHeadingAsync(pinCommand);
                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdateHeading(UpdateHeadingCommandVM command)
        {
            try
            {
                UpdateHeadingCommand updateHeading = _mapper.Map<UpdateHeadingCommand>(command);
                var response = await _client.UpdateHeadingAsync(updateHeading);
                return _mapper.Map<ApiResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
