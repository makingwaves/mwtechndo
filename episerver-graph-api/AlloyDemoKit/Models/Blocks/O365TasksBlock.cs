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

    }
}