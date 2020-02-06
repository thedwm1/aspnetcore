// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class AccessTokenRequestOptions
    {
        public IReadOnlyList<string> Scopes { get; set; }

        public string ReturnUrl { get; set; }
    }
}
