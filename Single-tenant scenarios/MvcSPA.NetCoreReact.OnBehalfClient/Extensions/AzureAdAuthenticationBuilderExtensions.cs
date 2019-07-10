using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace MvcSPA.NetCoreReact.OnBehalfClient.Extensions
{
    public static class AzureAdAuthenticationBuilderExtensions
    {
        public const string ObjectIdentifierType = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        public const string TenantIdType = "http://schemas.microsoft.com/identity/claims/tenantid";

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
                options.Authority = $"{azureOptions.Instance}common";
                //options.Authority = $"{azureOptions.Instance}{azureOptions.TenantId}"; //vv1.0 endpoint
                options.UseTokenLifetime = true;
                options.CallbackPath = azureOptions.CallbackPath;
                options.RequireHttpsMetadata = false;
                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                //var allScopes = $"{azureOptions.Scopes} {azureOptions.GraphScopes}".Split(new[] {' '});
                //foreach (var scope in allScopes) { options.Scope.Add(scope); }
                //options.Scope.Add("https://makingwaves.onmicrosoft.com/MiddleTier.NetCore20.OnBehalfOf/.default");
                var resource = "140794c2-d299-4d79-bcf5-6ccf4d5fff38"; //middle tier
                options.Scope.Add(resource + "/.default");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",
                    ValidateIssuer = false,
                };
                options.Events = new OpenIdConnectEvents
                {
                    OnTicketReceived = context =>
                    {
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
                        var identifier = context.Principal.FindFirst(ObjectIdentifierType).Value;

                        var credential = new ClientCredential(azureOptions.ClientId, "Oc9gD+xE1hWNt/1w2PBAGWw3V2kmWtJL5Wugk80bwYc=");

                        AuthenticationContext authContext = new AuthenticationContext(options.Authority, TokenCache.DefaultShared);
                        AuthenticationResult result = authContext.AcquireTokenByAuthorizationCodeAsync(code, new Uri("https://localhost:44372" + options.CallbackPath), credential, resource).Result;

                        context.HandleCodeRedemption(result.AccessToken, result.IdToken);
                    },
                    OnTokenValidated = context =>
                    {
                        var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
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
