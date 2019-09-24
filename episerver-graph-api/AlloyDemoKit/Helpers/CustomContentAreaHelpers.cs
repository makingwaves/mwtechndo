using EpiServer.AlloyDemo.GraphAPI.Business;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiServer.AlloyDemo.GraphAPI.Helpers
{
    public static class ContentAreaHtmlHelpers
    {
        internal static Injected<NoDivContentAreaRenderer> NoDivContentAreaRenderer;

        public static void RenderNoDivContentAreaRenderer(this HtmlHelper htmlHelper, ContentArea contentArea)
        {
            NoDivContentAreaRenderer.Service.Render(htmlHelper, contentArea);
        }
    }
}