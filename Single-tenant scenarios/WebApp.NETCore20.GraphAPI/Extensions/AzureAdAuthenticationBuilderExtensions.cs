using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using WebApp.NETCore20.GraphAPI.Helpers;

namespace WebApp.NETCore20.GraphAPI.Extensions
{
    public static class AzureAdAuthenticationBuilderExtensions
    {        
        public static AuthenticationBuilder AddAzureAd(this AuthenticationBuilder builder)
            => builder.AddAzureAd(_ => { });

        public static AuthenticationBuilder AddAzureAd(this AuthenticationBuilder builder, Action<AzureAdOptions> configureOptions)
        {
            builder.Services.Configure(configureOptions);
            builder.Services.AddSingleton<IConfigureOptions<OpenIdConnectOptions>, ConfigureAzureOptions>();
            builder.AddOpenIdConnect();
            return builder;
        }

        public class ConfigureAzureOptions: IConfigureNamedOptions<OpenIdConnectOptions>
        {
            private readonly AzureAdOptions azureOptions;
            private readonly IConfiguration configuration;

            public AzureAdOptions GetAzureAdOptions() => azureOptions;

            public ConfigureAzureOptions(IOptions<AzureAdOptions> azureOptions, IConfiguration configuration)
            {
                this.azureOptions = azureOptions.Value;
                this.configuration = configuration;
            }

            public void Configure(string name, OpenIdConnectOptions options)
            {
                options.ClientId = azureOptions.ClientId;
                //options.Authority = $"{azureOptions.Instance}common/v2.0";
                options.Authority = $"{azureOptions.Instance}{azureOptions.TenantId}"; //vv1.0 endpoint
                options.UseTokenLifetime = true;
                options.CallbackPath = azureOptions.CallbackPath;
                options.RequireHttpsMetadata = false;
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                var allScopes = $"{azureOptions.Scopes} {azureOptions.GraphScopes}".Split(new[] {' '});
                foreach (var scope in allScopes) { options.Scope.Add(scope); }

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Ensure that User.Identity.Name is set correctly after login
                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",

                    // Instead of using the default validation (validating against a single issuer value, as we do in line of business apps),
                    // we inject our own multitenant validation logic
                    ValidateIssuer = false,

                    // If the app is meant to be accessed by entire organizations, add your issuer validation logic here.
                    //IssuerValidator = (issuer, securityToken, validationParameters) => {
                    //    if (myIssuerValidationLogic(issuer)) return issuer;
                    //}
                };

                options.Events = new OpenIdConnectEvents
                {
                    OnTicketReceived = context =>
                    {
                        // If your authentication logic is based on users then add your logic here
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        context.Response.Redirect("/Home/Error");
                        context.HandleResponse(); // Suppress the exception
                        return Task.CompletedTask;
                    },
                    OnAuthorizationCodeReceived = async (context) =>
                    {
                        var code = context.ProtocolMessage.Code;
                        var identifier = context.Principal.FindFirst(Startup.ObjectIdentifierType).Value;
                        var memoryCache = context.HttpContext.RequestServices.GetRequiredService<IMemoryCache>();
                        //var graphScopes = azureOptions.GraphScopes.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var graphScopes = new[] { azureOptions.GraphResourceId + ".default" };

                        ClientCredential applicationCredentials = null;

                        if (azureOptions.UseMSI)
                        {
                            string appSecret = configuration["webapp-client-secret"];
                            applicationCredentials = new ClientCredential(appSecret);
                        }
                        else
                        {
                            var clientAssertionCertPfx = CertificateHelper.FindCertificateBySubjectName(azureOptions.ClientCertificate);
                            applicationCredentials = new ClientCredential(new ClientAssertionCertificate(clientAssertionCertPfx));
                        }

                        string authorityFormat = "https://login.microsoftonline.com/{0}";

                        var cca = new ConfidentialClientApplication(
                            azureOptions.ClientId,
                            string.Format(authorityFormat, azureOptions.TenantId),
                            azureOptions.BaseUrl + azureOptions.CallbackPath,
                            applicationCredentials,  
                            new SessionTokenCache(identifier, memoryCache).GetCacheInstance(),
                            null);

                        var result = await cca.AcquireTokenByAuthorizationCodeAsync(code, graphScopes);

                        //Check whether the login is from the MSA tenant. t.
                        //var currentTenantId = context.Principal.FindFirst(Startup.TenantIdType).Value;
                        //if (currentTenantId == "9188040d-6c67-4c5b-b112-36a304b66dad")
                        //{
                            // MSA (Microsoft Account) is used to log in
                        //}

                        context.HandleCodeRedemption(result.AccessToken, result.IdToken);
                    },
                    OnTokenValidated = context =>
                    {
                        var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                        //claimsIdentity.AddClaim(new Claim("test", "helloworld!!!"));

                        return Task.FromResult(0);
                    }
                };
            }

            public void Configure(OpenIdConnectOptions options)
            {
                Configure(Options.DefaultName, options);
            }
        }
    }
}
