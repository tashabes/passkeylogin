using BookApp.Blazor.WebAssemb.UI.Services.Base;

namespace BookApp.Blazor.WebAssemb.UI.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserDto loginModel);
        public Task Logout();
    }
}