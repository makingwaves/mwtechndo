using System.Web;
using System.Web.Mvc;

namespace WebApp.DotNet46.WSFederation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
