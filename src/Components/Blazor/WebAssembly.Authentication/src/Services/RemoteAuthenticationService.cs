// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationService<TRemoteAuthenticationState, TProviderOptions> : AuthenticationStateProvider, IRemoteAuthenticationService<TRemoteAuthenticationState>
         where TRemoteAuthenticationState : RemoteAuthenticationState
         where TProviderOptions : new()
    {
        protected readonly IJSRuntime _jsRuntime;
        protected readonly RemoteAuthenticationOptions<TProviderOptions> _options;

        public RemoteAuthenticationService(
            IJSRuntime jsRuntime,
            IOptions<RemoteAuthenticationOptions<TProviderOptions>> options)
        {
            _jsRuntime = jsRuntime;
            _options = options.Value;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync() => new AuthenticationState(await GetCurrentUser());

        public virtual async Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> SignInAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context)
        {
            await EnsureAuthService();
            var result = await _jsRuntime.InvokeAsync<RemoteAuthenticationResult<TRemoteAuthenticationState>>("AuthenticationService.signIn", context.State);
            if (result.Status == RemoteAuthenticationStatus.Success)
            {
                UpdateUser(GetCurrentUser());
            }

            return result;
        }

        public virtual async Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> CompleteSignInAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context)
        {
            await EnsureAuthService();
            var result = await _jsRuntime.InvokeAsync<RemoteAuthenticationResult<TRemoteAuthenticationState>>("AuthenticationService.completeSignIn", context.Url);
            if (result.Status == RemoteAuthenticationStatus.Success)
            {
                UpdateUser(GetCurrentUser());
            }

            return result;
        }

        public virtual async Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> SignOutAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context) => await _jsRuntime.InvokeAsync<RemoteAuthenticationResult<TRemoteAuthenticationState>>("AuthenticationService.signOut", context.State);

        public virtual async Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> CompleteSignOutAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context)
        {
            await EnsureAuthService();
            var result = await _jsRuntime.InvokeAsync<RemoteAuthenticationResult<TRemoteAuthenticationState>>("AuthenticationService.completeSignOut", context.Url);
            if (result.Status == RemoteAuthenticationStatus.Success)
            {
                UpdateUser(GetCurrentUser());
            }

            return result;
        }

        public virtual ValueTask<AccessTokenResult> GetAccessToken() => _jsRuntime.InvokeAsync<AccessTokenResult>("AuthenticationService.getAccessToken");

        public virtual ValueTask<AccessTokenResult> GetAccessToken(AccessTokenRequestOptions options) => _jsRuntime.InvokeAsync<AccessTokenResult>("AuthenticationService.getAccessToken", options);

        public virtual async Task<ClaimsPrincipal> GetCurrentUser()
        {
            await EnsureAuthService();
            var user = await _jsRuntime.InvokeAsync<IDictionary<string, object>>("AuthenticationService.getUser");

            var identity = user != null ? new ClaimsIdentity(
                _options.UserOptions.AuthenticationType,
                _options.UserOptions.NameClaim,
                _options.UserOptions.RoleClaim) : new ClaimsIdentity();

            if (user != null)
            {
                foreach (var kvp in user)
                {
                    var name = kvp.Key;
                    var value = kvp.Value;
                    if (value != null)
                    {
                        if (value is JsonElement element && element.ValueKind == JsonValueKind.Array)
                        {
                            foreach (var item in element.EnumerateArray())
                            {
                                identity.AddClaim(new Claim(name, JsonSerializer.Deserialize<object>(item.GetRawText()).ToString()));
                            }
                        }
                        else
                        {
                            identity.AddClaim(new Claim(name, value.ToString()));
                        }
                    }
                }

                if (_options.UserOptions.ScopeClaim != null)
                {
                    var result = await GetAccessToken();
                    if (result.Status == AccessTokenResultStatus.Success)
                    {
                        foreach (var scope in result.Token.GrantedScopes)
                        {
                            identity.AddClaim(new Claim(_options.UserOptions.ScopeClaim, scope));
                        }
                    }
                }
            }

            var principal = new ClaimsPrincipal(identity);

            return principal;
        }

        private async ValueTask EnsureAuthService() => await _jsRuntime.InvokeVoidAsync("AuthenticationService.init", _options.ProviderOptions);

        private void UpdateUser(Task<ClaimsPrincipal> task)
        {
            NotifyAuthenticationStateChanged(UpdateAuthenticationState(task));

            static async Task<AuthenticationState> UpdateAuthenticationState(Task<ClaimsPrincipal> futureUser) => new AuthenticationState(await futureUser);
        }
    }
}
