using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer.AlloyDemo.GraphAPI.Business
{
    public class ViewTemplateModelRegistrator : IViewTemplateModelRegistrator
    {
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            //viewTemplateModelRegistrator.Add(typeof(O365HiBlock),
            //    new EPiServer.DataAbstraction.TemplateModel()
            //    {
            //        Name = "SidebarTeaser",
            //        Description = "Displays a teaser of a page.",
            //        Path = "~/Views/Shared/O365HiBlock.cshtml",
            //        Tags = new string[] { RenderingTags.Sidebar }, 
            //    });
        }
    }
}