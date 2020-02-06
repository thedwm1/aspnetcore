using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class RemoteAuthenticationContext<TRemoteAuthenticationState> where TRemoteAuthenticationState : RemoteAuthenticationState
    {
        public string Url { get; set; }

        public TRemoteAuthenticationState State { get; set; }
    }
}
