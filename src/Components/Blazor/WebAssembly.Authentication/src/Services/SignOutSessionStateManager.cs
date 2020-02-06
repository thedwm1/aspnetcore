// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Microsoft.AspNetCore.Components.WebAssembly.Authentication
{
    public class SignOutSessionStateManager
    {
        private readonly IJSRuntime _jsRuntime;
        private static readonly JsonSerializerOptions SerializationOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        };

        public bool ValidSignOutState { get; set; } = false;

        public SignOutSessionStateManager(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask SetSignOutState()
        {
            return _jsRuntime.InvokeVoidAsync(
                "sessionStorage.setItem",
                "Microsoft.AspNetCore.Components.WebAssembly.Authentication.SignOutState",
                JsonSerializer.Serialize(SignOutState.Instance, SerializationOptions));
        }

        public async Task<bool> ValidateSignOutState()
        {
            var state = await GetSignOutState();
            if (state.Local)
            {
                await ClearSignOutState();
                ValidSignOutState = true;
            }

            return ValidSignOutState;
        }

        private async ValueTask<SignOutState> GetSignOutState()
        {
            var result = await _jsRuntime.InvokeAsync<string>(
                "sessionStorage.getItem",
                "Microsoft.AspNetCore.Components.WebAssembly.Authentication.SignOutState");
            if (result == null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<SignOutState>(result, SerializationOptions);
        }

        private ValueTask ClearSignOutState()
        {
            return _jsRuntime.InvokeVoidAsync(
                "sessionStorage.removeItem",
                "Microsoft.AspNetCore.Components.WebAssembly.Authentication.SignOutState");
        }

        private struct SignOutState
        {
            public static readonly SignOutState Instance = new SignOutState { Local = true };

            public bool Local { get; set; }
        }
    }
}
