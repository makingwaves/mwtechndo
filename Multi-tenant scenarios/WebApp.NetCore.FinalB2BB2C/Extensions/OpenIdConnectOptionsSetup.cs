using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace WebApp.NetCore.FinalB2BB2C.Extensions
{
    public static class AzureAdB2CAuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddAzureAdB2C_Personal(this AuthenticationBuilder builder)
            => builder.AddAzureAdB2C_Personal(_ => { });

        public static AuthenticationBuilder AddAzureAdB2C_Personal(this AuthenticationBuilder builder,
            Action<AzureAdB2COptions> configureOptions)
        {
            builder.Services.Configure(configureOptions);
            builder.Services.AddSingleton<IConfigureOptions<OpenIdConnectOptions>, OpenIdConnectOptionsSetup>();
            builder.AddOpenIdConnect();
            return builder;
        }

        public class OpenIdConnectOptionsSetup : IConfigureNamedOptions<OpenIdConnectOptions>
        {
            private readonly AzureAdB2COptions azureAdB2COptions;
            private readonly IConfiguration configuration;

            public OpenIdConnectOptionsSetup(IOptions<AzureAdB2COptions> b2cOptions, IConfiguration configuration)
            {
                this.azureAdB2COptions = b2cOptions.Value;
                this.configuration = configuration;
            }

            public void Configure(string name, OpenIdConnectOptions options)
            {
                string personalAuthority = $"{this.azureAdB2COptions.Instance}/{this.azureAdB2COptions.Tenant}/{this.azureAdB2COptions.DefaultSignUpSignPolicy}/v2.0";
                string businessAuthority = $"{this.azureAdB2COptions.Instance}/{this.azureAdB2COptions.Tenant}/{this.azureAdB2COptions.BusinessSignUpSignPolicy}/v2.0";
                string resetPasswordAuthority = $"{this.azureAdB2COptions.Instance}/{this.azureAdB2COptions.Tenant}/{this.azureAdB2COptions.ResetPasswordPolicyId}/v2.0";
                string profileEditAuthority = $"{this.azureAdB2COptions.Instance}/{this.azureAdB2COptions.Tenant}/{this.azureAdB2COptions.EditProfilePolicyId}/v2.0";

                string personalOpenIDConfiguration = $"{personalAuthority}/.well-known/openid-configuration";
                string businessOpenIDConfiguration = $"{businessAuthority}/.well-known/openid-configuration";
                string resetPasswordOpenIDConfiguration = $"{resetPasswordAuthority}/.well-known/openid-configuration";
                string editProfileOpenIDConfiguration = $"{profileEditAuthority}/.well-known/openid-configuration";

                IConfigurationManager<OpenIdConnectConfiguration> peronsalConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(personalOpenIDConfiguration, new OpenIdConnectConfigurationRetriever());
                OpenIdConnectConfiguration personalOpenIdConfig = peronsalConfigurationManager.GetConfigurationAsync(CancellationToken.None).Result;

                IConfigurationManager<OpenIdConnectConfiguration> businessConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(businessOpenIDConfiguration, new OpenIdConnectConfigurationRetriever());
                OpenIdConnectConfiguration businessOpenIdConfig = businessConfigurationManager.GetConfigurationAsync(CancellationToken.None).Result;

                IConfigurationManager<OpenIdConnectConfiguration> resetPasswordConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(resetPasswordOpenIDConfiguration, new OpenIdConnectConfigurationRetriever());
                OpenIdConnectConfiguration resetPasswordOpenIdConfig = resetPasswordConfigurationManager.GetConfigurationAsync(CancellationToken.None).Result;

                IConfigurationManager<OpenIdConnectConfiguration> editProfileConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(editProfileOpenIDConfiguration, new OpenIdConnectConfigurationRetriever());
                OpenIdConnectConfiguration editProfileOpenIdConfig = editProfileConfigurationManager.GetConfigurationAsync(CancellationToken.None).Result;

                var allSigningKeys = personalOpenIdConfig.SigningKeys
                    .Concat(businessOpenIdConfig.SigningKeys)
                    .Concat(resetPasswordOpenIdConfig.SigningKeys)
                    .Concat(editProfileOpenIdConfig.SigningKeys);

                options.ClientId = this.azureAdB2COptions.ClientId;
                options.Authority = personalAuthority;
                options.UseTokenLifetime = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    NameClaimType = "name", 
                    IssuerSigningKeys = allSigningKeys
                };

                options.Events = new OpenIdConnectEvents()
                {
                    OnRedirectToIdentityProvider = OnRedirectToIdentityProvider,
                    OnRemoteFailure = OnRemoteFailure,
                    OnAuthorizationCodeReceived = OnAuthorizationCodeReceived, 
                    OnTokenValidated = OnTokenValidated, 
                };
            }

            public void Configure(OpenIdConnectOptions options)
            {
                Configure(Options.DefaultName, options);
            }

            public Task OnRedirectToIdentityProvider(RedirectContext context)
            {
                var defaultPolicy = this.azureAdB2COptions.DefaultSignUpSignPolicy;

                context.ProtocolMessage.Scope = OpenIdConnectScope.OpenIdProfile;
                context.ProtocolMessage.ResponseType = OpenIdConnectResponseType.CodeIdToken;

                //b2c policy
                string logintype = null;
                context.Properties.Items.TryGetValue("logintype", out logintype);
                if (logintype != null && logintype.Equals("personal"))
                {
                    string policy = this.azureAdB2COptions.DefaultSignUpSignPolicy;

                    context.ProtocolMessage.IssuerAddress = context.ProtocolMessage.IssuerAddress.ToLower().Replace(defaultPolicy.ToLower(), policy.ToLower());
                    context.Properties.Items.Remove(AzureAdB2COptions.PolicyAuthenticationProperty);
                }
                else if (logintype != null && logintype.Equals("business"))
                {
                    string policy = this.azureAdB2COptions.BusinessSignUpSignPolicy;

                    context.ProtocolMessage.IssuerAddress = context.ProtocolMessage.IssuerAddress.ToLower().Replace(defaultPolicy.ToLower(), policy.ToLower());
                    context.Properties.Items.Remove(AzureAdB2COptions.PolicyAuthenticationProperty);
                }
                else if (logintype != null && logintype.Equals("resetpassword"))
                {
                    string policy = this.azureAdB2COptions.ResetPasswordPolicyId;

                    context.ProtocolMessage.IssuerAddress = context.ProtocolMessage.IssuerAddress.ToLower().Replace(defaultPolicy.ToLower(), policy.ToLower());
                    context.Properties.Items.Remove(AzureAdB2COptions.PolicyAuthenticationProperty);
                }
                else if (logintype != null && logintype.Equals("profileedit"))
                {
                    string policy = this.azureAdB2COptions.EditProfilePolicyId;

                    context.ProtocolMessage.IssuerAddress = context.ProtocolMessage.IssuerAddress.ToLower().Replace(defaultPolicy.ToLower(), policy.ToLower());
                    context.Properties.Items.Remove(AzureAdB2COptions.PolicyAuthenticationProperty);
                }

                //scope
                if (!string.IsNullOrEmpty(this.azureAdB2COptions.ApiUrl))
                {
                    context.ProtocolMessage.Scope += $" offline_access {this.azureAdB2COptions.ApiScopes}";
                }

                return Task.FromResult(0);
            }

            public Task OnRemoteFailure(RemoteFailureContext context)
            {
                context.HandleResponse();

                // Handle the error code that Azure AD B2C throws when trying to reset a password from the login page 
                // because password reset is not supported by a "sign-up or sign-in policy"
                if (context.Failure is OpenIdConnectProtocolException &&
                    context.Failure.Message.Contains("AADB2C90118"))
                {
                    // If the user clicked the reset password link, redirect to the reset password route
                    context.Response.Redirect("/Session/ResetPassword");
                }
                else if (context.Failure is OpenIdConnectProtocolException &&
                         context.Failure.Message.Contains("access_denied"))
                {
                    context.Response.Redirect("/");
                }
                else
                {
                    var message = Regex.Replace(context.Failure.Message, @"[^\u001F-\u007F]+", string.Empty);
                    context.Response.Redirect("/Home/Error?message=" + message);
                }

                return Task.FromResult(0);
            }

            public async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
            {
                var defaultPolicy = this.azureAdB2COptions.DefaultSignUpSignPolicy;
                string authority = "";

                string logintype = null;
                context.Properties.Items.TryGetValue("logintype", out logintype);
                if (logintype != null && logintype.Equals("personal"))
                {
                    authority = $"{this.azureAdB2COptions.Instance}/{this.azureAdB2COptions.Tenant}/{this.azureAdB2COptions.DefaultSignUpSignPolicy}/v2.0";
                    string policy = this.azureAdB2COptions.DefaultSignUpSignPolicy;

                    context.ProtocolMessage.IssuerAddress = context.ProtocolMessage.IssuerAddress.ToLower().Replace(defaultPolicy.ToLower(), policy.ToLower());
                    context.Properties.Items.Remove(AzureAdB2COptions.PolicyAuthenticationProperty);
                }
                else if (logintype != null && logintype.Equals("business"))
                {
                    authority = $"{this.azureAdB2COptions.Instance}/{this.azureAdB2COptions.Tenant}/{this.azureAdB2COptions.BusinessSignUpSignPolicy}/v2.0";
                    string policy = this.azureAdB2COptions.BusinessSignUpSignPolicy;

                    context.ProtocolMessage.IssuerAddress = context.ProtocolMessage.IssuerAddress.ToLower().Replace(defaultPolicy.ToLower(), policy.ToLower());
                    context.Properties.Items.Remove(AzureAdB2COptions.PolicyAuthenticationProperty);
                }
                else if (logintype != null && logintype.Equals("resetpassword"))
                {
                    authority = $"{this.azureAdB2COptions.Instance}/{this.azureAdB2COptions.Tenant}/{this.azureAdB2COptions.ResetPasswordPolicyId}/v2.0";
                    string policy = this.azureAdB2COptions.ResetPasswordPolicyId;

                    context.ProtocolMessage.IssuerAddress = context.ProtocolMessage.IssuerAddress.ToLower().Replace(defaultPolicy.ToLower(), policy.ToLower());
                    context.Properties.Items.Remove(AzureAdB2COptions.PolicyAuthenticationProperty);
                }
                else if (logintype != null && logintype.Equals("profileedit"))
                {
                    authority = $"{this.azureAdB2COptions.Instance}/{this.azureAdB2COptions.Tenant}/{this.azureAdB2COptions.EditProfilePolicyId}/v2.0";
                    string policy = this.azureAdB2COptions.EditProfilePolicyId;

                    context.ProtocolMessage.IssuerAddress = context.ProtocolMessage.IssuerAddress.ToLower().Replace(defaultPolicy.ToLower(), policy.ToLower());
                    context.Properties.Items.Remove(AzureAdB2COptions.PolicyAuthenticationProperty);
                }

                // Use MSAL to swap the code for an access token
                // Extract the code from the response notification
                var code = context.ProtocolMessage.Code;

                string signedInUserID = context.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
                IConfidentialClientApplication cca = ConfidentialClientApplicationBuilder
                    .Create(this.azureAdB2COptions.ClientId)
                    .WithB2CAuthority(authority)
                    .WithRedirectUri(this.azureAdB2COptions.RedirectUri)
                    .WithClientSecret(this.configuration["b2c-application-2-secret"])
                    .Build();

                try
                {
                    AuthenticationResult result = await cca
                        .AcquireTokenByAuthorizationCode(this.azureAdB2COptions.ApiScopes.Split(' '), code)
                        .ExecuteAsync();

                    context.HandleCodeRedemption(result.AccessToken, result.IdToken);
                }
                catch (Exception ex)
                {
                    //TODO: Handle
                    throw;
                }
            }

            private Task OnTokenValidated(TokenValidatedContext arg)
            {
                var claimsIdentity = (ClaimsIdentity)arg.Principal.Identity;
                Claim idp = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/identityprovider");
                if (idp == null) //means that user was self-registered
                {

                }

                //if (idp.Value.Equals("google.com")) //"live.com" 
                //{
                //    Claim emailClaim = claimsIdentity.Claims.First(c => c.Type == "emails");
                //    claimsIdentity.AddClaim(new Claim("name", emailClaim.Value));
                //}

                Claim emailClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "emails");
                if (emailClaim == null)
                {
                    emailClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
                }

                claimsIdentity.AddClaim(new Claim("name", emailClaim.Value));

                return Task.FromResult(0);
            }
        }
    }
}
