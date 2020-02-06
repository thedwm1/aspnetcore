using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public interface IAccessTokenProvider
    {
        ValueTask<AccessTokenResult> GetAccessToken();

        ValueTask<AccessTokenResult> GetAccessToken(AccessTokenRequestOptions options);
    }
}
