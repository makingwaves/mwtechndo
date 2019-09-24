using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using StructureMap.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpiServer.AlloyDemo.GraphAPI.Business
{
    [ServiceConfiguration(typeof(NoDivContentAreaRenderer), Lifecycle = ServiceInstanceScope.Transient)]
    public class NoDivContentAreaRenderer : ContentAreaRenderer
    {
        public Injected<IContentAreaItemAttributeAssembler> AttributeAssembler;

        protected override void RenderContentAreaItem(HtmlHelper htmlHelper, ContentAreaItem contentAreaItem, string templateTag, string htmlTag, string cssClass)
        {
            var dictionary = new Dictionary<string, object>
            {
                ["childrencustomtagname"] = htmlTag,
                ["childrencssclass"] = cssClass,
                ["tag"] = templateTag
            };

            dictionary = contentAreaItem.RenderSettings.Concat(
                (
                from r in dictionary
                where !contentAreaItem.RenderSettings.ContainsKey(r.Key)
                select r
                )
            ).ToDictionary(r => r.Key, r => r.Value);

            htmlHelper.ViewBag.RenderSettings = dictionary;
            var content = contentAreaItem.GetContent();

            if (content == null)
                return;

            using (new ContentAreaContext(htmlHelper.ViewContext.RequestContext, content.ContentLink))
            {
                var templateModel = ResolveTemplate(htmlHelper, content, templateTag);
                if ((templateModel == null) && !IsInEditMode(htmlHelper))
                    return;

                if (IsInEditMode(htmlHelper))
                {
                    var tagBuilder = new TagBuilder(htmlTag);
                    AddNonEmptyCssClass(tagBuilder, cssClass);
                    tagBuilder.MergeAttributes(AttributeAssembler.Service.GetAttributes(contentAreaItem, IsInEditMode(htmlHelper), templateModel != null));
                    BeforeRenderContentAreaItemStartTag(tagBuilder, contentAreaItem);
                    htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
                    htmlHelper.RenderContentData(content, true);
                    htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.EndTag));
                }
                else
                {
                    htmlHelper.RenderContentData(content, true);
                }
            }
        }

        protected override bool ShouldRenderWrappingElement(HtmlHelper htmlHelper)
        {
            return false;
        }
    }
}