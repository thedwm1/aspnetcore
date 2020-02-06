namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationActions
    {
        public const string Login = "login";
        public const string LoginCallback = "login-callback";
        public const string LoginFailed = "login-failed";
        public const string Profile = "profile";
        public const string Register = "register";
        public const string Logout = "logout";
        public const string LogoutCallback = "logout-callback";
        public const string LogoutFailed = "logout-failed";
        public const string LogoutSucceeded = "logged-out";

        public static bool IsAction(string action, string candidate) =>
            action != null && string.Equals(action, candidate, System.StringComparison.OrdinalIgnoreCase);
    }
}
