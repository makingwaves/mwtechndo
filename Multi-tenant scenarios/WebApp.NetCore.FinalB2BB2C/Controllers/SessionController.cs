using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using WebApp.NetCore.FinalB2BB2C.Controllers;
using WebApp.NetCore.FinalB2BB2C.Extensions;

namespace WebApp.NetCore.MultiTenant.Controllers
{
    public class SessionController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IOptions<AzureAdB2COptions> azureOptions;

        public SessionController(IOptions<AzureAdB2COptions> azureOptions)
        {
            this.azureOptions = azureOptions;
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            var redirectUrl = Url.Action(nameof(HomeController.Index), "Home");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl, Items = { { "logintype", "resetpassword" } } };
            return Challenge(properties, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var redirectUrl = Url.Action(nameof(HomeController.Index), "Home");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl, Items = { { "logintype", "profileedit" } } };
            return Challenge(properties, OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
