/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;

namespace WebApp.NETCore20.GraphAPI.Helpers
{
    public class GraphSdkHelper : IGraphSdkHelper
    {
        private readonly IGraphAuthProvider authProvider;
        private GraphServiceClient graphClient;
        private IHttpContextAccessor httpContextAccessor;

        public GraphSdkHelper(IGraphAuthProvider authProvider, IHttpContextAccessor httpContextAccessor)
        {
            this.authProvider = authProvider;
            this.httpContextAccessor = httpContextAccessor;
        }

        // Get an authenticated Microsoft Graph Service client.
        public GraphServiceClient GetAuthenticatedClientForUser()
        {
            string userId = this.httpContextAccessor.HttpContext.User.FindFirst(Startup.ObjectIdentifierType)?.Value;

            graphClient = new GraphServiceClient("https://graph.microsoft.com/beta", new DelegateAuthenticationProvider(
                async requestMessage =>
                {
                    // Passing tenant ID to the sample auth provider to use as a cache key
                    var accessToken = await authProvider.GetUserAccessTokenAsync(userId);

                    // Append the access token to the request
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }));

            return graphClient;
        }

        public GraphServiceClient GetAuthenticatedClientForApplication()
        {
            graphClient = new GraphServiceClient("https://graph.microsoft.com/beta", new DelegateAuthenticationProvider(
                async requestMessage =>
                {
                    // Passing tenant ID to the sample auth provider to use as a cache key
                    var accessToken = await authProvider.GetApplicationAccessTokenAsync();

                    // Append the access token to the request
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }));

            return graphClient;
        }
    }
    public interface IGraphSdkHelper
    {
        GraphServiceClient GetAuthenticatedClientForUser();
        GraphServiceClient GetAuthenticatedClientForApplication();
    }
}
