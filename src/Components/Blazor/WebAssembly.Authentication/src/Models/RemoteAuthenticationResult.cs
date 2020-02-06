namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationResult<TState> where TState : class
    {
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public TState State { get; set; }
    }
}
