using System.Web.ApplicationServices;
using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Auth;
using EpiServer.AlloyDemo.GraphAPI.Business.Data;
using EpiServer.AlloyDemo.GraphAPI.Business.Rendering;
using EPiServer.ContentApi.Core.Internal;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using RoleService = System.Web.ApplicationServices.RoleService;

namespace EpiServer.AlloyDemo.GraphAPI.Business.Initialization
{
    [InitializableModule]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {

            //Implementations for custom interfaces can be registered here.

            context.ConfigurationComplete += (o, e) =>
            {
                //Register custom implementations that should be used in favour of the default implementations
                context.Services.AddTransient<IContentRenderer, ErrorHandlingContentRenderer>()
                    .AddTransient<ContentAreaRenderer, AlloyContentAreaRenderer>()
                    .AddTransient<IFileDataImporter, FileDataImporter>()
                    .AddTransient<UserService, CustomUserService>();
            };
        }

        public void Initialize(InitializationEngine context)
        {
            DependencyResolver.SetResolver(new ServiceLocatorDependencyResolver(context.Locate.Advanced));
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}
