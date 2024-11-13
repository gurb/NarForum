using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace NarForumUser.Client.Services.Common
{
    public class ImageProvider
    {
        public Dictionary<string, string?> Images { get; set; }

        [Inject]
        private  IJSRuntime? jsRuntime { get; set; }

        bool IsWASM;

        HttpClient? httpClient { get; set; }

        private readonly IConfiguration configuration;

        public ImageProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            Images = new Dictionary<string, string?>();
            IsWASM = jsRuntime is IJSInProcessRuntime;
        }

        public async Task<string?> GetImage(string imageUrl)
        {
            if(IsWASM)
            {
                if (Images.ContainsKey(imageUrl))
                {
                    return "data:image/png;base64," + Images[imageUrl];
                }
                else
                {
                    string? base64 = await ImageUrlToBase64($"{configuration["ApiBaseUrl"]}/file/images/{imageUrl}");

                    Images.Add(imageUrl, base64);

                    return "data:image/png;base64," + base64;
                }
            }
            else
            {
                return $"{configuration["ApiBaseUrl"]}/file/images/{imageUrl}";
            }
        }

        private async Task<string?> ImageUrlToBase64(string imageUrl)
        {
            HttpResponseMessage response = await httpClient.GetAsync(imageUrl);
            if (response.IsSuccessStatusCode)
            {
                var imageBytes = await response.Content.ReadAsByteArrayAsync();

                return Convert.ToBase64String(imageBytes);
            }
            else
            {
                return null;
            }
        }
    }
}
