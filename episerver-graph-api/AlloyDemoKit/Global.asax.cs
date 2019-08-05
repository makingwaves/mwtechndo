using EPiServer.Cms.UI.AspNetIdentity;
using System.Data.Entity;
using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EpiServer.AlloyDemo.GraphAPI
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }
    }
}