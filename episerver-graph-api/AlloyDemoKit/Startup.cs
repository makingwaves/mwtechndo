using System;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Runtime.Caching;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using EpiServer.AlloyDemo.GraphAPI;
using EpiServer.AlloyDemo.GraphAPI.Business;
using EpiServer.AlloyDemo.GraphAPI.Helpers;
using EPiServer.Cms.UI.AspNetIdentity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace EpiServer.AlloyDemo.GraphAPI
{
    public class Startup
    {
        public const string ObjectIdentifierType = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        private static readonly string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        public static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static readonly string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];
        private static readonly string authority = ConfigurationManager.AppSettings["ida:Authority"];
        private static string aadAuthority = String.Format(CultureInfo.InvariantCulture, aadInstance, authority);

        const string LogoutPath = "/logout";
        public const string ClientSecret = "UQMY7@AEg.pI@QbbJED4zCxkthQ^G1UG";

        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = clientId,
                Authority = aadAuthority,
                RedirectUri = postLogoutRedirectUri,
                PostLogoutRedirectUri = postLogoutRedirectUri,
                ResponseType = OpenIdConnectResponseType.CodeIdToken,
         
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    RoleClaimType = ClaimTypes.Role
                },
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    RedirectToIdentityProvider = async (n) =>
                    {
                        n.ProtocolMessage.RedirectUri = postLogoutRedirectUri;
                        await Task.FromResult(0);
                    },
                    AuthorizationCodeReceived = async (context) =>
                    {
                        var code = context.Code;
                        string signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;

                        var credential = new ClientCredential(clientId, ClientSecret);

                        AuthenticationContext authContext = new AuthenticationContext(aadAuthority, TokenCache.DefaultShared);
                        AuthenticationResult result = authContext.AcquireTokenByAuthorizationCodeAsync(code, new Uri(postLogoutRedirectUri), credential, "https://graph.microsoft.com/").Result;
                    },
                    AuthenticationFailed = context =>
                    {
                        context.HandleResponse();
                        context.Response.Write(context.Exception.Message);
                        return Task.FromResult(0);
                    },
                    SecurityTokenValidated = (context) =>
                    {
                        context.AuthenticationTicket.Properties.RedirectUri = postLogoutRedirectUri;
                        return Task.FromResult(0);
                    }
                }
            });

            app.UseStageMarker(PipelineStage.Authenticate);
            app.Map(LogoutPath, map =>
            {
                map.Run(ctx =>
                {
                    ctx.Authentication.SignOut();
                    return Task.FromResult(0);
                });
            });

            // Add CMS integration for ASP.NET Identity
            app.AddCmsAspNetIdentity<ApplicationUser>();

            // Remove to block registration of administrators
            app.UseSetupAdminAndUsersPage(() => HttpContext.Current.Request.IsLocal);           
        }

        private Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
        {
            context.HandleResponse();
            context.Response.Redirect("/?errormessage=" + context.Exception.Message);
            return Task.FromResult(0);
        }
    }
}
