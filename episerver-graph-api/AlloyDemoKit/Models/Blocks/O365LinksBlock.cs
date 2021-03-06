﻿using EPiServer.Core;
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
    [SiteContentType(GUID = "0ea4b1af-a5c0-41d0-94ef-9099190db743", DisplayName = "O365 Links Block")]
    [SiteImageUrl]
    public class O365LinksBlock : BaseO365Block
    {

    }
}