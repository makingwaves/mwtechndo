using EPiServer.ContentApi.Cms;
using EPiServer.ContentApi.Core.Configuration;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer.AlloyDemo.GraphAPI.Auth
{
    [ModuleDependency(typeof(ContentApiCmsInitialization))]
    public class ExtendedContentApiCmsInitialization : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }
        public void Uninitialize(InitializationEngine context)
        {
        }
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<ContentApiConfiguration>(config =>
            {
                config.Default()
                .SetMinimumRoles("CmsAdmins")
                .SetRequiredRole("CmsAdmins")
                .SetSiteDefinitionApiEnabled(true)
                .SetMultiSiteFilteringEnabled(false);
            });
        }
    }
}