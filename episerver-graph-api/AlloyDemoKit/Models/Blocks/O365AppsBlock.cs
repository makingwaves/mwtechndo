using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpiServer.AlloyDemo.GraphAPI.Models.Blocks
{
    /// <summary>
    /// Used to insert a list of date pages where blogs are created
    /// </summary>
    [SiteContentType(GUID = "1ee73e08-d38c-47e4-b160-3f58a2417187", DisplayName = "O365 Apps Block")]
    [SiteImageUrl]
    public class O365AppsBlock : BaseO365Block
    {
        [Display(Order = 1, Name = "Heading", GroupName = SystemTabNames.Content)]
        [DefaultValue("Test")]
        public virtual string Heading { get; set; }

        [Display(Order = 2, Name = "Background color", GroupName = SystemTabNames.Settings)]
        [DefaultValue("lightblue")]
        public virtual string BackgroundColor { get; set; }
    }
}