using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models.Heading;
using BlazorUI.Models.Post;
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
            var headings = await _client.HeadingsAllAsync();
            var data = _mapper.Map<List<HeadingVM>>(headings);

            return data;
        }

        public async Task<List<HeadingVM>> GetHeadingsByCategoryId(int id)
        {
            var headings = await _client.GetHeadingsByCategoryIdAsync(id);
            var data = _mapper.Map<List<HeadingVM>>(headings);

            return data;
        }

        public async Task<List<HeadingVM>> GetHeadingsByCategoryName(string name)
        {
            var headings = await _client.GetHeadingsByCategoryNameAsync(name);
            var data = _mapper.Map<List<HeadingVM>>(headings);

            return data;
        }
    }
}
