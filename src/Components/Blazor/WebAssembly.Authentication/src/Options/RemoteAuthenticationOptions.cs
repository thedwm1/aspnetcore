namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationOptions<TRemoteAuthenticationProviderOptions> where TRemoteAuthenticationProviderOptions: new()
    {
        public TRemoteAuthenticationProviderOptions ProviderOptions { get; set; } = new TRemoteAuthenticationProviderOptions();

        public RemoteAuthenticationApplicationPathsOptions AuthenticationPaths { get; set; } = new RemoteAuthenticationApplicationPathsOptions();

        public RemoteAuthenticationUserOptions UserOptions { get; set; } = new RemoteAuthenticationUserOptions();
    }
}
