using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EpiServer.AlloyDemo.GraphAPI.Models.Blocks
{
    public class BaseO365Block : SiteBlockData
    {
        public string AccessToken {
            get
            {
                var authority = "https://login.microsoftonline.com/makingwaves.onmicrosoft.com";
                var resource = "https://graph.microsoft.com/";

                var clientId = ConfigurationManager.AppSettings["ida:ClientId"];

                AuthenticationContext authContext = new AuthenticationContext(authority, TokenCache.DefaultShared);
                AuthenticationResult result = authContext.AcquireTokenSilentAsync(resource, clientId).Result;

                return result.AccessToken;
            }
        }
    }
}