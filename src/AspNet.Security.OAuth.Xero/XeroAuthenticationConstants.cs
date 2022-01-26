﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

namespace AspNet.Security.OAuth.Xero;

/// <summary>
/// Contains constants specific to the <see cref="XeroAuthenticationHandler"/>.
/// </summary>
public static class XeroAuthenticationConstants
{
    public static class ClaimNames
    {
        /// <summary>
        /// Unique user identifier.
        /// </summary>
        public const string UserId = "xero_userid";

        /// <summary>
        /// User email address.
        /// </summary>
        public const string Email = "email";
    }
}
