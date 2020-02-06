// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationOptions<TRemoteAuthenticationProviderOptions> where TRemoteAuthenticationProviderOptions: new()
    {
        public TRemoteAuthenticationProviderOptions ProviderOptions { get; set; } = new TRemoteAuthenticationProviderOptions();

        public RemoteAuthenticationApplicationPathsOptions AuthenticationPaths { get; set; } = new RemoteAuthenticationApplicationPathsOptions();

        public RemoteAuthenticationUserOptions UserOptions { get; set; } = new RemoteAuthenticationUserOptions();
    }
}
