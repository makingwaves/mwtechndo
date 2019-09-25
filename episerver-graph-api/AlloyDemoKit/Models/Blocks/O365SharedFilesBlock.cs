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
    [SiteContentType(GUID = "20e20887-d4c6-48dd-9996-1dd1fe3c53ed", DisplayName = "O365 SharedFiles Block")]
    [SiteImageUrl]
    public class O365SharedFilesBlock : BaseO365Block
    {

    }
}