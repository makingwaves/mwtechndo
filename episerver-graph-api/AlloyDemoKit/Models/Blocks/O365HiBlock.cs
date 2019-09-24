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
    [SiteContentType(GUID = "b9efffd8-2620-4600-89a9-440f23e7f91f", DisplayName = "O365 Hi! Block")]
    [SiteImageUrl]
    public class O365HiBlock : BaseO365Block
    {
        [Display(Order = 1, Name = "Heading", GroupName = SystemTabNames.Content)]
        [DefaultValue("Test")]
        public virtual string Heading { get; set; }

        [Display(Order = 2, Name = "Background color", GroupName = SystemTabNames.Settings)]
        [DefaultValue("lightgreen")]
        public virtual string BackgroundColor { get; set; }
    }
}