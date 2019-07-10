using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using WebApp.NetCore.MultiTenant.Extensions;

namespace WebApp.NetCore.MultiTenant.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IOptions<AzureAdOptions> azureOptions;

        public AccountController(IOptions<AzureAdOptions> azureOptions, IConfiguration configuration)
        {
            this.azureOptions = azureOptions;
            this.configuration = configuration;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAccessToken()
        {
            var authority = "https://login.windows.net/882c3105-af5d-4b6c-8ab1-d0271766eb79/";

            var resource = "140794c2-d299-4d79-bcf5-6ccf4d5fff38"; //middle tier
            var clientId = azureOptions.Value.ClientId;

            AuthenticationContext authContext = new AuthenticationContext(authority, TokenCache.DefaultShared);
            AuthenticationResult result = await authContext.AcquireTokenSilentAsync(resource, clientId);

            return Json(result.AccessToken);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var redirectUrl = Url.Action(nameof(HomeController.Index), "Home");
            return Challenge(
                new AuthenticationProperties { RedirectUri = redirectUrl },
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            var callbackUrl = Url.Action(nameof(SignedOut), "Account", values: null, protocol: Request.Scheme);
            return SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult SignedOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Redirect to home page if the user is authenticated.
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
