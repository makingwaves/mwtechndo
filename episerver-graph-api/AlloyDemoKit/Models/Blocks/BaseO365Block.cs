using EPiServer.DataAbstraction;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EpiServer.AlloyDemo.GraphAPI.Models.Blocks
{
    public class BaseO365Block : SiteBlockData
    {
        [Display(Order = 1, Name = "Heading", GroupName = SystemTabNames.Content)]
        [DefaultValue("Test")]
        public virtual string Heading { get; set; }

        [Display(Order = 2, Name = "Section title", GroupName = SystemTabNames.Content)]
        [DefaultValue("Test")]
        public virtual string SectionTitle { get; set; }

        [Display(Order = 3, Name = "Graph API Url", GroupName = SystemTabNames.Settings)]
        [DefaultValue("lightblue")]
        public virtual string GraphAPIUrl { get; set; }

        [Display(Order = 4, Name = "Background color", GroupName = SystemTabNames.Settings)]
        [DefaultValue("bisque")]
        public virtual string BackgroundColor { get; set; }

        public string AccessToken {
            get
            {
                var authority = "https://login.microsoftonline.com/makingwaves.onmicrosoft.com";
                var resource = "https://graph.microsoft.com/";

                var clientId = ConfigurationManager.AppSettings["ida:ClientId"];

                AuthenticationContext authContext = new AuthenticationContext(authority, TokenCache.DefaultShared);
                AuthenticationResult result = authContext.AcquireTokenSilentAsync(resource, clientId).Result;

                return result.AccessToken;
            }
        }
    }
}