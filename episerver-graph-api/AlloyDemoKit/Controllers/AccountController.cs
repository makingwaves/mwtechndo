using EpiServer.AlloyDemo.GraphAPI.Helpers;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Configuration;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IOptions<AzureAdOptions> azureOptions;

        public AccountController()
        {
            //this.azureOptions = azureOptions;
        }

        public async Task<JsonResult> GetAccessToken()
        {
            var authority = "https://login.windows.net/882c3105-af5d-4b6c-8ab1-d0271766eb79/";

            var resource = "https://graph.microsoft.com/";
            //var clientId = azureOptions.Value.ClientId;
            var clientId = ConfigurationManager.AppSettings["ida:ClientId"];

            AuthenticationContext authContext = new AuthenticationContext(authority, TokenCache.DefaultShared);
            AuthenticationResult result = await authContext.AcquireTokenSilentAsync(resource, clientId);

            return Json(result.AccessToken);
        }
    }
}