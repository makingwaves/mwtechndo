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
    [SiteContentType(GUID = "7a3631d7-2533-4200-84ba-4b2476e15e30", DisplayName = "O365 Video Block")]
    [SiteImageUrl]
    public class O365VideoBlock : BaseO365Block
    {
        [Display(Order = 1, Name = "Heading", GroupName = SystemTabNames.Content)]
        [DefaultValue("Test")]
        public virtual string Heading { get; set; }

        [Display(Order = 2, Name = "Background color", GroupName = SystemTabNames.Settings)]
        [DefaultValue("lightblue")]
        public virtual string BackgroundColor { get; set; }
    }
}