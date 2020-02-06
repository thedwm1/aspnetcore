using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationDefaults
    {
        public const string LoginPath = "authentication/login";
        public const string LoginCallbackPath = "authentication/login-callback";
        public const string LoginFailedPath = "authentication/login-failed";
        public const string LogoutPath = "authentication/logout";
        public const string LogoutCallbackPath = "authentication/logout-callback";
        public const string LogoutFailedPath = "authentication/logout-failed";
        public const string LogoutSucceededPath = "authentication/logged-out";
    }
}
