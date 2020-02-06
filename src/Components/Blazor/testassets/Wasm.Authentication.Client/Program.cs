using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Wasm.Authentication.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = "https://accounts.google.com/";
                options.ProviderOptions.ClientId = "1048855053233-16qpvegahk2leksb6q2hheoas56pfib9.apps.googleusercontent.com";

            });

            //builder.Services.AddMsalSpaAuthentication(options =>
            //{
            //    var authentication = options.ProviderOptions.Authentication;
            //    authentication.Authority = "https://login.microsoftonline.com/7e511586-66ec-4108-bc9c-a68dee0dc2aa";
            //    authentication.ClientId = "ae13253e-6630-48c2-9f99-52ec618d9c4c";

            //    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://BlazorWasmAadAPI/All");
            //});

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
