namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class AccessTokenResult
    {
        public string Status { get; set; }
        public AccessToken Token { get; set; }
        public string RedirectUrl { get; set; }
    }
}
