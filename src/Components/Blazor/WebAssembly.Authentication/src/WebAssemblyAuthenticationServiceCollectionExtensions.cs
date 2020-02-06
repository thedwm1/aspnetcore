// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Reflection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebAssemblyAuthenticationServiceCollectionExtensions
    {
        public static IServiceCollection AddSpaAuthentication<TRemoteAuthenticationState, TProviderOptions>(this IServiceCollection services)
            where TRemoteAuthenticationState : RemoteAuthenticationState
            where TProviderOptions : new()
        {
            services.AddOptions();
            services.AddAuthorizationCore();
            services.TryAddSingleton<AuthenticationStateProvider, RemoteAuthenticationService<TRemoteAuthenticationState, TProviderOptions>>();
            services.TryAddSingleton(sp =>
                {
                    return (IRemoteAuthenticationService<TRemoteAuthenticationState>)sp.GetRequiredService<AuthenticationStateProvider>();
                });

            services.TryAddSingleton(sp =>
            {
                return (IAccessTokenProvider)sp.GetRequiredService<AuthenticationStateProvider>();
            });

            services.TryAddSingleton<SignOutSessionStateManager>();

            return services;
        }

        public static IServiceCollection AddSpaAuthentication<TRemoteAuthenticationState, TProviderOptions>(this IServiceCollection services, Action<RemoteAuthenticationOptions<TProviderOptions>> configure)
            where TRemoteAuthenticationState : RemoteAuthenticationState
            where TProviderOptions : new()
        {
            services.AddSpaAuthentication<RemoteAuthenticationState, TProviderOptions>();
            if (configure != null)
            {
                services.Configure(configure);
            }

            return services;
        }

        public static IServiceCollection AddOidcAuthentication(this IServiceCollection services, Action<RemoteAuthenticationOptions<OidcProviderOptions>> configure)
        {
            AddSpaAuthentication<RemoteAuthenticationState, OidcProviderOptions>(services, configure);

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<RemoteAuthenticationOptions<OidcProviderOptions>>, DefaultOidcOptionsConfiguration>());

            if (configure != null)
            {
                services.Configure(configure);
            }

            return services;
        }

        // These are the special methods for when your SPA is integrated with the ASP.NET SPA authentication infrastructure
        // We need to find a good name for these.
        public static IServiceCollection AddApiAuthorization(this IServiceCollection services)
        {
            var inferredClientId = Assembly.GetCallingAssembly().GetName().Name;

            services.AddSpaAuthentication<RemoteAuthenticationState, ApiAuthorizationProviderOptions>();

            services.TryAddEnumerable(
                ServiceDescriptor.Singleton<IPostConfigureOptions<RemoteAuthenticationOptions<ApiAuthorizationProviderOptions>>, DefaultApiAuthorizationOptionsConfiguration>(_ =>
                new DefaultApiAuthorizationOptionsConfiguration(inferredClientId)));

            return services;
        }

        public static IServiceCollection AddApiAuthorization(this IServiceCollection services, Action<RemoteAuthenticationOptions<ApiAuthorizationProviderOptions>> configure)
        {
            services.AddApiAuthorization();

            if (configure != null)
            {
                services.Configure(configure);
            }

            return services;
        }
    }
}
