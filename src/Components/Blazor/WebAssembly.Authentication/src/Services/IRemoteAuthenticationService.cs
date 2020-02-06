// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public interface IRemoteAuthenticationService<TRemoteAuthenticationState> : IAccessTokenProvider
        where TRemoteAuthenticationState : RemoteAuthenticationState
    {
        Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> SignInAsync(RemoteAuthenticationContext<TRemoteAuthenticationState> context);

        Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> CompleteSignInAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context);

        Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> SignOutAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context);

        Task<RemoteAuthenticationResult<TRemoteAuthenticationState>> CompleteSignOutAsync(
            RemoteAuthenticationContext<TRemoteAuthenticationState> context);

        Task<ClaimsPrincipal> GetCurrentUser();
    }
}
