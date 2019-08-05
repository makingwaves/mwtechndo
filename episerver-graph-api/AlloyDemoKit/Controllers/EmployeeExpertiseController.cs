using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EpiServer.AlloyDemo.GraphAPI.Models.ViewModels;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.UI;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class EmployeeExpertiseController :  PageControllerBase<EmployeeExpertise>
    {
        private const int MaxResults = 1000;
        private readonly IClient _searchClient;
        private readonly IFindUIConfiguration _findUIConfiguration;

        public EmployeeExpertiseController(
            IClient searchClient, 
            IFindUIConfiguration findUIConfiguration)
        {
            _searchClient = searchClient;
            _findUIConfiguration = findUIConfiguration;
        }

        [ValidateInput(false)]
        public ViewResult Index(EmployeeExpertise currentPage, string q)
        {
            var model = new EmployeeExpertiseContentModel(currentPage);

            var query = _searchClient.Search<EmployeePage>()
                                    .Filter(x => x.EmployeeExpertiseList.Match(currentPage.Name));

            if (this.ControllerContext.RequestContext.HttpContext.Request.QueryString["location"] != null)
            {
                string qs = this.ControllerContext.RequestContext.HttpContext.Request.QueryString["location"].ToString();
                query = query.Filter(x => x.EmployeeLocation.Match(qs));
            }

            query = query.TermsFacetFor(x => x.EmployeeLocation);

            model.FindResult = query.Take(100).GetPagesResult();

            return View(model);
        }

     

       
    }
}
