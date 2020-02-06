// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationResult<TState> where TState : class
    {
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public TState State { get; set; }
    }
}
