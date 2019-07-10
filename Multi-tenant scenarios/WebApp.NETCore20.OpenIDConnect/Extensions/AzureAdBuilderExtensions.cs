using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using WebApp.NETCore.MultiTenantPlusMSA.Models;
using WebApp.NETCore20.OpenIDConnect;

namespace WebApp.NETCore.MultiTenantPlusMSA.Extensions
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

        public class ConfigureAzureOptions : IConfigureNamedOptions<OpenIdConnectOptions>
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
                options.Authority = $"{azureOptions.Instance}{azureOptions.TenantId}/v2.0"; //vv2.0 endpoint
                options.UseTokenLifetime = true;
                options.CallbackPath = azureOptions.CallbackPath;
                options.RequireHttpsMetadata = false;
                options.ResponseType = OpenIdConnectResponseType.IdToken;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Ensure that User.Identity.Name is set correctly after login
                    NameClaimType = "preferred_username",
                    ValidateIssuer = false,
                };

                options.Events.OnTokenValidated += OnTokenValidated;
            }

            private Task OnTokenValidated(TokenValidatedContext arg)
            {
                var claimsIdentity = (ClaimsIdentity)arg.Principal.Identity;

                //Claim emailClaim = claimsIdentity.Claims.First(c => c.Type == "preferred_username");
                //claimsIdentity.AddClaim(new Claim("name", emailClaim.Value));

                return Task.FromResult(0);
            }

            public void Configure(OpenIdConnectOptions options)
            {
                Configure(Options.DefaultName, options);
            }
        }
    }
}
