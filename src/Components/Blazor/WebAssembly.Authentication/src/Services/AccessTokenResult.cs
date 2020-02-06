// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class AccessTokenResult
    {
        public string Status { get; set; }
        public AccessToken Token { get; set; }
        public string RedirectUrl { get; set; }
    }
}
