// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationUserOptions
    {
        public string NameClaim { get; set; } = "name";

        public string RoleClaim { get; set; }

        public string ScopeClaim { get; set; }

        public string AuthenticationType { get; set; }
    }
}
