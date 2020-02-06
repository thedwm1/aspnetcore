using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public interface IRemoteAuthenticationService<TRemoteAuthenticationState> : IAccessTokenProvider
        where TRemoteAuthenticationState : RemoteAuthenticationState
    {
        Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> SignInAsync(RemoteAuthenticationContext<TRemoteAuthenticationState> context);

        Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> CompleteSignInAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context);

        Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> SignOutAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context);

        Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> CompleteSignOutAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context);

        Task<ClaimsPrincipal> GetCurrentUser();
    }
}
