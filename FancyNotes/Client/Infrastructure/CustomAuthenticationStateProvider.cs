using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Security.Claims;

namespace FancyNotes.Infrastructure
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        private ClaimsPrincipal anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try 
            {
                var userSession = await _localStorage.GetItemAsync<UserSession>("UserSession");
                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(anonymous));
                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSession.UserName),
                new Claim(ClaimTypes.NameIdentifier,userSession.Id.ToString())
            }, "CustomAuth"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch 
            {
                return await Task.FromResult(new AuthenticationState(anonymous));
            }
            
        }

        public async Task UpdateAuthenticationState(UserSession userSession) 
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null)
            {
                await _localStorage.SetItemAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSession.UserName),
                new Claim(ClaimTypes.NameIdentifier,userSession.Id.ToString())
            }));
            }
            else
            {
                await _localStorage.RemoveItemAsync("UserSession");
                claimsPrincipal = anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

    }
}
