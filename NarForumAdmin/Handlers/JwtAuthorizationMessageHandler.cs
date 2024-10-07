using NarForumAdmin.Services.Common;
using System.Net.Http.Headers;

namespace NarForumAdmin.Handlers
{
    public class JwtAuthorizationMessageHandler : DelegatingHandler
    {
        private readonly LocalStorageService _localStorageService;

        public JwtAuthorizationMessageHandler(LocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorageService.GetItem("token");
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
