// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
