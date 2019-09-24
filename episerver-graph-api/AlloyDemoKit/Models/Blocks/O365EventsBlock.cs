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
    [SiteContentType(GUID = "f55253f7-59f3-48af-bd06-193c34084bf5", DisplayName = "O365 Events Block")]
    [SiteImageUrl]
    public class O365EventsBlock : BaseO365Block
    {
        [Display(Order = 1, Name = "Heading", GroupName = SystemTabNames.Content)]
        [DefaultValue("Test")]
        public virtual string Heading { get; set; }

        [Display(Order = 2, Name = "Background color", GroupName = SystemTabNames.Settings)]
        [DefaultValue("bisque")]
        public virtual string BackgroundColor { get; set; }
    }
}