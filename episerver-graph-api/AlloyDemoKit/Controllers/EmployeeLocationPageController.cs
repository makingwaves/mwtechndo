using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EpiServer.AlloyDemo.GraphAPI.Models.ViewModels;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.UI;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class EmployeeLocationPageController :  PageControllerBase<EmployeeLocationPage>
    {
        private const int MaxResults = 1000;
        private readonly IClient _searchClient;
        private readonly IFindUIConfiguration _findUIConfiguration;

        public EmployeeLocationPageController(
            IClient searchClient, 
            IFindUIConfiguration findUIConfiguration)
        {
            _searchClient = searchClient;
            _findUIConfiguration = findUIConfiguration;
        }

        [ValidateInput(false)]
        public ViewResult Index(EmployeeLocationPage currentPage, string q)
        {
            var model = new EmployeeSearchContentModel(currentPage)
                {
                    PublicProxyPath = _findUIConfiguration.AbsolutePublicProxyPath()
                };

            var query = _searchClient.Search<EmployeePage>()
                                    .Filter(x => x.EmployeeLocation.Match(currentPage.Name));

            if (this.ControllerContext.RequestContext.HttpContext.Request.QueryString["expertise"] != null)
            {
                string qs = this.ControllerContext.RequestContext.HttpContext.Request.QueryString["expertise"].ToString();
                query = query.Filter(x => x.EmployeeExpertiseList.Match(qs));
            }

            query = query.TermsFacetFor(x => x.EmployeeExpertiseList).OrderBy(x => x.LastName);

            model.FindResult = query.Take(100).GetPagesResult();

            return View(model);
        }

     

       
    }
}
