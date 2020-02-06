namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class DefaultAuthenticationManager : AuthenticationManager<RemoteAuthenticationState>
    {
        public DefaultAuthenticationManager() => AuthenticationState = new RemoteAuthenticationState();
    }
}
