using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Business;
using EpiServer.AlloyDemo.GraphAPI.Models.Pages.Blog;
using EpiServer.AlloyDemo.GraphAPI.Models.ViewModels;
using EPiServer;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class BlogStartPageController : PageControllerBase<BlogStartPage>
    {
        private readonly ContentLocator contentLocator;
        private readonly IContentLoader contentLoader;

        public BlogStartPageController(ContentLocator contentLocator, IContentLoader contentLoader)
        {
            this.contentLocator = contentLocator;
            this.contentLoader = contentLoader;
        }

        public ActionResult Index(BlogStartPage currentPage)
        {

            var model = new PageViewModel<BlogStartPage>(currentPage);

            return View(model);
        }


    }
}
