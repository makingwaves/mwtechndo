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
    [SiteContentType(GUID = "1d5aa24c-dddd-484c-90ca-c706ef6cc142", DisplayName = "O365 Tasks Block")]
    [SiteImageUrl]
    public class O365TasksBlock : BaseO365Block
    {
        [Display(Order = 1, Name = "Heading", GroupName = SystemTabNames.Content)]
        [DefaultValue("Test")]
        public virtual string Heading { get; set; }

        [Display(Order = 2, Name = "Background color", GroupName = SystemTabNames.Settings)]
        [DefaultValue("lightblue")]
        public virtual string BackgroundColor { get; set; }
    }
}