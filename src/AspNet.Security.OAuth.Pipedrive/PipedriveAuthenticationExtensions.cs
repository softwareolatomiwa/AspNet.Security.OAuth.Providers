﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.Extensions.DependencyInjection;

namespace AspNet.Security.OAuth.Pipedrive;

/// <summary>
/// Extension methods to add Pipedrive authentication capabilities to an HTTP application pipeline.
/// </summary>
public static class PipedriveAuthenticationExtensions
{
    /// <summary>
    /// Adds <see cref="PipedriveAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables Pipedrive authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static AuthenticationBuilder AddPipedrive([NotNull] this AuthenticationBuilder builder)
    {
        return builder.AddPipedrive(PipedriveAuthenticationDefaults.AuthenticationScheme, options => { });
    }

    /// <summary>
    /// Adds <see cref="PipedriveAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables Pipedrive authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="configuration">The delegate used to configure the OpenID 2.0 options.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static AuthenticationBuilder AddPipedrive(
        [NotNull] this AuthenticationBuilder builder,
        [NotNull] Action<PipedriveAuthenticationOptions> configuration)
    {
        return builder.AddPipedrive(PipedriveAuthenticationDefaults.AuthenticationScheme, configuration);
    }

    /// <summary>
    /// Adds <see cref="PipedriveAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables Pipedrive authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="scheme">The authentication scheme associated with this instance.</param>
    /// <param name="configuration">The delegate used to configure the Pipedrive options.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddPipedrive(
        [NotNull] this AuthenticationBuilder builder,
        [NotNull] string scheme,
        [NotNull] Action<PipedriveAuthenticationOptions> configuration)
    {
        return builder.AddPipedrive(scheme, PipedriveAuthenticationDefaults.DisplayName, configuration);
    }

    /// <summary>
    /// Adds <see cref="PipedriveAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables Pipedrive authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="scheme">The authentication scheme associated with this instance.</param>
    /// <param name="caption">The optional display name associated with this instance.</param>
    /// <param name="configuration">The delegate used to configure the Pipedrive options.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddPipedrive(
        [NotNull] this AuthenticationBuilder builder,
        [NotNull] string scheme,
        [CanBeNull] string caption,
        [NotNull] Action<PipedriveAuthenticationOptions> configuration)
    {
        return builder.AddOAuth<PipedriveAuthenticationOptions, PipedriveAuthenticationHandler>(scheme, caption, configuration);
    }
}