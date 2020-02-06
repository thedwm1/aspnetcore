using System.Collections.Generic;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class AccessTokenRequestOptions
    {
        public IReadOnlyList<string> Scopes { get; set; }

        public string ReturnUrl { get; set; }
    }
}
