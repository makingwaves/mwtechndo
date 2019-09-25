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
    [SiteContentType(GUID = "e1490ce1-fea2-4a96-a00a-76bf90696607", DisplayName = "O365 Recent Files Block")]
    [SiteImageUrl]
    public class O365RecentFilesBlock : BaseO365Block
    {

    }
}