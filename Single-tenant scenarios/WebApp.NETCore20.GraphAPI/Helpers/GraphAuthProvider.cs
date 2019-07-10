using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using WebApp.NETCore20.GraphAPI.Extensions;

namespace WebApp.NETCore20.GraphAPI.Helpers
{
    public class GraphAuthProvider : IGraphAuthProvider
    {
        private readonly IMemoryCache memoryCache;
        private readonly AzureAdOptions azureOptions;
        private readonly IConfiguration configuration;

        public GraphAuthProvider(IMemoryCache memoryCache, IConfiguration configuration)
        {
            this.memoryCache = memoryCache;
            this.configuration = configuration;

            var azureOptions = new AzureAdOptions();
            configuration.Bind("AzureAd", azureOptions);

            this.azureOptions = azureOptions;
        }

        public async Task<string> GetUserAccessTokenAsync(string userId)
        {
            ClientCredential credential = null;

            if (azureOptions.UseMSI)
            {
                string appSecret = configuration["webapp-client-secret"];
                credential = new ClientCredential(appSecret);
            }
            else
            {
                var clientAssertionCertPfx = CertificateHelper.FindCertificateBySubjectName(azureOptions.ClientCertificate);
                credential = new ClientCredential(new ClientAssertionCertificate(clientAssertionCertPfx));
            }

            //Standard certificate credential
            string appId = azureOptions.ClientId;
            string authority = $"{azureOptions.Instance}{azureOptions.TenantId}";
            string[] scopes = azureOptions.GraphScopes.Split(new[] { ' ' });
            string redirectUri = azureOptions.BaseUrl + azureOptions.CallbackPath;

            var userTokenCache = new SessionTokenCache(userId, memoryCache).GetCacheInstance();
            var cca = new ConfidentialClientApplication(appId, authority, redirectUri, credential, userTokenCache, null);

            var accounts = (await cca.GetAccountsAsync()).ToList();
            if (!accounts.Any()) throw new ServiceException(new Error
            {
                Code = "TokenNotFound",
                Message = "User not found in token cache. Maybe the server was restarted."
            });

            try
            {
                var result = await cca.AcquireTokenSilentAsync(scopes, accounts.First());
                return result.AccessToken;
            }

            catch (Exception ex)
            {
                throw new ServiceException(new Error
                {
                    Code = GraphErrorCode.AuthenticationFailure.ToString(),
                    Message = "Caller needs to authenticate. Unable to retrieve the access token silently."
                });
            }
        }

        // Gets an access token. First tries to get the access token from the token cache.
        // Using certificate to authenticate.
        public async Task<string> GetApplicationAccessTokenAsync()
        {
            //Standard certificate credential
            string appId = azureOptions.ClientId;
            string authority = $"{azureOptions.Instance}{azureOptions.TenantId}";
            //in this case SCOPES ARE STATIC (not dynamic like in user-context where user can chooose permissions to grant)
            string[] scopes = new string[] { azureOptions.GraphResourceId + "/.default" };
            string redirectUri = azureOptions.BaseUrl + azureOptions.CallbackPath;

            //var clientAssertionCertPfx = CertificateHelper.FindCertificateBySubjectName(azureOptions.ClientCertificate);
            //ClientCredential credential = new ClientCredential(new ClientAssertionCertificate(clientAssertionCertPfx));

            string appSecret = configuration["webapp-client-secret"];
            ClientCredential credential = new ClientCredential(appSecret);

            var cca = new ConfidentialClientApplication(appId, authority, redirectUri, credential, new TokenCache(), null);

            try
            {
                var result = await cca.AcquireTokenForClientAsync(scopes);
                return result.AccessToken;
            }

            catch (Exception ex)
            {
                throw new ServiceException(new Error
                {
                    Code = GraphErrorCode.AuthenticationFailure.ToString(),
                    Message = "Caller needs to authenticate. Unable to retrieve the access token silently."
                });
            }
        }
    }

    public interface IGraphAuthProvider
    {
        Task<string> GetUserAccessTokenAsync(string userId);
        Task<string> GetApplicationAccessTokenAsync();
    }
}
