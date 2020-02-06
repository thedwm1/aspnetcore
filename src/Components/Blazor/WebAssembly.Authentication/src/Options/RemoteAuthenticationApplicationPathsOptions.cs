// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
