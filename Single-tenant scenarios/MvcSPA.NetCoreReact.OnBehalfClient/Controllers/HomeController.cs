using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using MvcSPA.NetCoreReact.OnBehalfClient.Extensions;
using MvcSPA.NetCoreReact.OnBehalfClient.Models;
using Newtonsoft.Json;

namespace MvcSPA.NetCoreReact.OnBehalfClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<AzureAdOptions> azureOptions;

        public HomeController(IOptions<AzureAdOptions> azureOptions)
        {
            this.azureOptions = azureOptions;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";

            string userId = User.FindFirst(Startup.ObjectIdentifierType)?.Value;
            UserIdentifier userIdentifier = new UserIdentifier(userId, UserIdentifierType.OptionalDisplayableId);

            //var authority = $"{azureOptions.Value.Instance}{azureOptions.Value.TenantId}";
            //var authority = $"{azureOptions.Value.Instance}common"; ;
            var authority = "https://login.windows.net/882c3105-af5d-4b6c-8ab1-d0271766eb79/";

            var resource = "140794c2-d299-4d79-bcf5-6ccf4d5fff38"; //middle tier
            var clientId = azureOptions.Value.ClientId;

            AuthenticationContext authContext = new AuthenticationContext(authority, TokenCache.DefaultShared);
            AuthenticationResult result = await authContext.AcquireTokenSilentAsync(resource, clientId);

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

            var response = await httpClient.GetAsync(@"https://localhost:44377/api/values?name=" + User.Identity.Name);
            string json = await response.Content.ReadAsStringAsync();

            return View("About", json);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
