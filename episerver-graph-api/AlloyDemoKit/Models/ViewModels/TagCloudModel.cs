using System.Collections.Generic;
using EpiServer.AlloyDemo.GraphAPI.Business.Blog;
using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;

namespace EpiServer.AlloyDemo.GraphAPI.Models.ViewModels
{
    public class TagCloudModel
    {
        public TagCloudModel(TagCloudBlock block)
        {
            Heading = block.Heading;    
        }

        public string Heading { get; set; }

        public IEnumerable<TagItem> Tags { get; set; }

    }
}