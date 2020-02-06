using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class WebAssemblyAuthenticationServiceCollectionExtensionsTests
    {
        [Fact]
        public void CanResolve_AccessTokenProvider()
        {
            var builder = WebAssemblyHostBuilder.CreateDefault();
            builder.Services.AddApiAuthorization();
            var host = builder.Build();

            host.Services.GetRequiredService<IAccessTokenProvider>();
        }
    }
}
