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

        HttpClient? httpClient { get; set; } = new HttpClient();

        private readonly IConfiguration configuration;

        private string? apiBase;

        public ImageProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            Images = new Dictionary<string, string?>();
            IsWASM = jsRuntime is IJSInProcessRuntime;
            if(configuration is not null)
            {
                apiBase = configuration["ApiBaseUrl"];
            }
        }

        public async Task<string?> GetImage(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new ArgumentNullException(nameof(imageUrl), "Image URL cannot be null or empty.");
            }
            if (OperatingSystem.IsBrowser())
            {
                if (Images.ContainsKey(imageUrl))
                {
                    return "data:image/png;base64," + Images[imageUrl];
                }
                else
                {
                    string? base64 = await ImageUrlToBase64($"{apiBase}/file/images/{imageUrl}");

                    if (base64 != null)
                    {
                        Images[imageUrl] = base64; 
                        return "data:image/png;base64," + base64;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return $"{apiBase}/file/images/{imageUrl}";
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
