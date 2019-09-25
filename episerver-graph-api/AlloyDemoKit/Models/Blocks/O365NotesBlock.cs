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
    [SiteContentType(GUID = "2d35fc5d-1f55-4c77-86e1-67fb909d3909", DisplayName = "O365 Notes Block")]
    [SiteImageUrl]
    public class O365NotesBlock : BaseO365Block
    {

    }
}