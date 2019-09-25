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
    [SiteContentType(GUID = "91f1cb64-f196-4983-a4c9-32e9d02bad0f", DisplayName = "O365 Poster Block")]
    [SiteImageUrl]
    public class O365PosterBlock : BaseO365Block
    {

    }
}