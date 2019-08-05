using EPiServer.Core;

namespace EpiServer.AlloyDemo.GraphAPI.Models.ViewModels
{
    public class ClosestLocationViewModel
    {
        public string Heading { get; set; }

        public string Description { get; set; }

        public ContentReference Image { get; set; }

        public ContentReference Link { get; set; }

        public string Name { get; set; }
    }
}
