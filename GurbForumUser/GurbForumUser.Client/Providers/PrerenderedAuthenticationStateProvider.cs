using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace GurbForumUser.Client.Providers
{
    public class PrerenderedAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Prerender sırasında anonim bir kullanıcı döndürüyoruz.
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            return Task.FromResult(new AuthenticationState(anonymousUser));
        }
    }
}
