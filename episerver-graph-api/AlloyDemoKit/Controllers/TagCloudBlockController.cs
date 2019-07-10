﻿using System.Collections.Generic;
using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Business;
using EpiServer.AlloyDemo.GraphAPI.Business.Blog;
using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;
using EpiServer.AlloyDemo.GraphAPI.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class TagCloudBlockController : BlockController<TagCloudBlock>
    {
        private readonly ContentLocator contentLocator;
        private IContentLoader contentLoader;
        public TagCloudBlockController(ContentLocator contentLocator, IContentLoader contentLoader)
        {
            this.contentLocator = contentLocator;
            this.contentLoader = contentLoader;
        }

        public override ActionResult Index(TagCloudBlock currentBlock)
        {
            var model = new TagCloudModel(currentBlock)
            {
                Tags = GetTags(currentBlock.BlogTagLinkPage)
            };
         
            return PartialView(model);
        }

        public IEnumerable<TagItem> GetTags(PageReference startTagLink)
        {
            List<TagItem> tags = new List<TagItem>();
            var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();

            foreach (var item in TagRepository.Instance.LoadTags())
            {
                Category cat = categoryRepository.Get(item.TagName);
                string url = string.Empty;

                if (startTagLink != null)
                {
                    url = TagFactory.Instance.GetTagUrl(contentLoader.Get<PageData>(startTagLink.ToPageReference()), cat);
                }

                tags.Add(new TagItem() { Count = item.Count, TagName = item.TagName, Weight = item.Weight, Url = url });
            }
            return tags;
        }

    }
}
