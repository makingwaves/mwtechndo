using System.Runtime.Caching;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Helpers;
using EpiServer.AlloyDemo.GraphAPI.Models.GraphApi;
using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EpiServer.AlloyDemo.GraphAPI.Models.ViewModels;
using EPiServer.Web.Mvc;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class GraphController : PageController<GraphApiPage>
    {
        public async Task<ActionResult> Index(GraphApiPage currentPage)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            if (principal.Identity.IsAuthenticated)
            {
                string upn = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn")?.Value;
                if (string.IsNullOrEmpty(upn))
                {
                    upn = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
                }

                upn = HttpUtility.UrlEncode(upn);

                //var graphService = ServiceLocator.Current.GetInstance<GraphService>();
                var graphProvider = new GraphAuthProvider(MemoryCache.Default);
                var graphService = new GraphService(MemoryCache.Default, new GraphSdkHelper(graphProvider), graphProvider);
                CompositeGraphObject compositeGraphObject = await graphService.GetUserJson(upn, null);

                currentPage.CompositeGraphObject = compositeGraphObject;

                return View(PageViewModel.Create(currentPage));
            }

            return View();
        }
    }
}