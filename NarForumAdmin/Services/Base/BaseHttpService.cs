using NarForumAdmin.Services.Common;

namespace NarForumAdmin.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected readonly LocalStorageService _localStorage;

        public BaseHttpService(IClient client, LocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new ApiResponse<Guid>() { Message = "Invalid data was submitted", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new ApiResponse<Guid>() { Message = "The record was not found.", Success = false };
            }
            else
            {
                return new ApiResponse<Guid>() { Message = "Something went wrong, please try again later.", Success = false };
            }
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainsKey("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    await _localStorage.GetItem("token"));
        }
    }
}
