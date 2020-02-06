// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    internal class DefaultApiAuthorizationOptionsConfiguration : IConfigureOptions<RemoteAuthenticationOptions<ApiAuthorizationProviderOptions>>
    {
        private readonly string _applicationName;

        public DefaultApiAuthorizationOptionsConfiguration(string applicationName)
        {
            _applicationName = applicationName;
        }

        public void Configure(RemoteAuthenticationOptions<ApiAuthorizationProviderOptions> options)
        {
            options.ProviderOptions.ClientId = _applicationName;
            options.AuthenticationPaths.RegisterPath = "Identity/Account/Register";
            options.AuthenticationPaths.ProfilePath = "Identity/Account/Manage";
            options.UserOptions.ScopeClaim = "scope";
            options.UserOptions.RoleClaim = "scope";
            options.UserOptions.AuthenticationType = _applicationName;
        }
    }
}
