using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models.Heading;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services
{
    public class HeadingService : BaseHttpService, IHeadingService
    {
        private readonly IMapper _mapper;
        public HeadingService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateHeading(HeadingVM post)
        {
            try
            {
                var createHeadingCommand = _mapper.Map<CreateHeadingCommand>(post);
                await _client.HeadingsAsync(createHeadingCommand);
                return new ApiResponse<Guid>
                {
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<HeadingVM>> GetHeadings()
        {
            var posts = await _client.HeadingsAllAsync();
            var data = _mapper.Map<List<HeadingVM>>(posts);

            return data;
        }

    }
}
