﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.AspNetCore.Builder;

namespace AspNet.Security.OAuth.LinkedIn;

public class LinkedInTests(ITestOutputHelper outputHelper) : OAuthTests<LinkedInAuthenticationOptions>(outputHelper)
{
    /*private Action<LinkedInAuthenticationOptions>? additionalConfiguration;*/

    public override string DefaultScheme => LinkedInAuthenticationDefaults.AuthenticationScheme;

    protected internal override void RegisterAuthentication(AuthenticationBuilder builder)
    {
        builder.AddLinkedIn(options =>
        {
            ConfigureDefaults(builder, options);
            /*additionalConfiguration?.Invoke(options);*/
        });
    }

    protected internal override void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("fr-FR"),
        });
    }

    [Theory]
    [InlineData(LinkedInAuthenticationConstants.Claims.Sub, "1R2RtA")]
    [InlineData(ClaimTypes.Name, "Frodo Baggins")]
    [InlineData(ClaimTypes.Email, "frodo@shire.middleearth")]
    [InlineData(ClaimTypes.GivenName, "Frodo")]
    [InlineData(ClaimTypes.Surname, "Baggins")]
    [InlineData(LinkedInAuthenticationConstants.Claims.Picture, "https://upload.wikimedia.org/wikipedia/en/4/4e/Elijah_Wood_as_Frodo_Baggins.png")]
    public async Task Can_Sign_In_Using_LinkedIn(string claimType, string claimValue)
    {
        // Arrange
        /*additionalConfiguration = options => options.Fields.Add(LinkedInAuthenticationConstants.ProfileFields.PictureUrl);*/

        await AuthenticateUserAndAssertClaimValue(claimType, claimValue);
    }
}
