namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationApplicationPathsOptions
    {
        public string RegisterPath { get; set; }

        public string ProfilePath { get; set; }

        public string LoginPath { get; set; } = RemoteAuthenticationDefaults.LoginPath;

        public string LoginCallbackPath { get; set; } = RemoteAuthenticationDefaults.LoginCallbackPath;

        public string LoginFailedPath { get; set; } = RemoteAuthenticationDefaults.LoginFailedPath;

        public string LogoutPath { get; set; } = RemoteAuthenticationDefaults.LogoutPath;

        public string LogoutCallbackPath { get; set; } = RemoteAuthenticationDefaults.LogoutCallbackPath;

        public string LogoutFailedPath { get; set; } = RemoteAuthenticationDefaults.LogoutFailedPath;

        public string LogoutSucceededPath { get; set; } = RemoteAuthenticationDefaults.LogoutSucceededPath;
    }
}
