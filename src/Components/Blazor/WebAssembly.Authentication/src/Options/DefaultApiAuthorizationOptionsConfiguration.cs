using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    internal class DefaultApiAuthorizationOptionsConfiguration : IConfigureOptions<RemoteAuthenticationOptions<ApiAuthorizationProviderOptions>>
    {
        private readonly string _applicationName;

        public DefaultApiAuthorizationOptionsConfiguration(string applicationName)
        {
            _applicationName = applicationName;
        }

        public void Configure(RemoteAuthenticationOptions<ApiAuthorizationProviderOptions> options)
        {
            options.ProviderOptions.ClientId = _applicationName;
            options.AuthenticationPaths.RegisterPath = "Identity/Account/Register";
            options.AuthenticationPaths.ProfilePath = "Identity/Account/Manage";
            options.UserOptions.ScopeClaim = "scope";
            options.UserOptions.RoleClaim = "scope";
            options.UserOptions.AuthenticationType = _applicationName;
        }
    }
}
