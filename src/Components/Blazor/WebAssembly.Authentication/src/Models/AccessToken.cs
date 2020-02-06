using System;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class AccessToken
    {
        public string [] GrantedScopes { get; set; }

        public DateTimeOffset Expires { get; set; }

        public string Value { get; set; }
    }
}
