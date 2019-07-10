using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebApp.NETCore20.GraphAPI.Extensions;
using WebApp.NETCore20.GraphAPI.Helpers;
using WebApp.NETCore20.GraphAPI.Models;
using WebApp.NETCore20.GraphAPI.Models.GraphApi;

namespace WebApp.NETCore20.GraphAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IOptions<AzureAdOptions> azureOptions;
        private readonly IMemoryCache memoryCache;
        private readonly GraphService graphService;

        public HomeController(IConfiguration configuration,
            IOptions<AzureAdOptions> azureOptions,
            IMemoryCache memoryCache,
            GraphService graphService)
        {
            this.configuration = configuration;
            this.azureOptions = azureOptions;
            this.memoryCache = memoryCache;
            this.graphService = graphService;
        }

        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            if (principal.Identity.IsAuthenticated)
            {
                string upn = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn")?.Value;
                upn = HttpUtility.UrlEncode(upn);

                string userId = principal.FindFirst(Startup.ObjectIdentifierType)?.Value;

                CompositeGraphObject compositeGraphObject = await graphService.GetUserJson(userId, null);

                return View(compositeGraphObject);
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
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
