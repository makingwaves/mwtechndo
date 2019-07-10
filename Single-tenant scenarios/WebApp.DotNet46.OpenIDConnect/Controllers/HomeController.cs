using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using WebApp.DotNet46.OpenIDConnect.Models;
using ClaimTypes = System.IdentityModel.Claims.ClaimTypes;

namespace WebApp.DotNet46.OpenIDConnect.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                //var tokenCache = TokenCache.DefaultShared;

                string signedInUserID = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier).Value;
                var cache = new ADALTokenCache(signedInUserID);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}