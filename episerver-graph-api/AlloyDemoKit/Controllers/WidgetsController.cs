using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EpiServer.AlloyDemo.GraphAPI.Models.ViewModels;
using EPiServer.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class WidgetsController : PageController<WidgetsPage>
    {
        public async Task<ActionResult> Index(WidgetsPage currentPage)
        {
            return View(PageViewModel.Create(currentPage));
        }
    }
}