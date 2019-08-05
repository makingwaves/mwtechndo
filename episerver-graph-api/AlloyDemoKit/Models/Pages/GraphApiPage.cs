using EpiServer.AlloyDemo.GraphAPI.Models.GraphApi;
using EPiServer.DataAnnotations;

namespace EpiServer.AlloyDemo.GraphAPI.Models.Pages
{
    [ContentType(DisplayName = "GraphApiPage", GUID = "50ed1e4d-ebb9-4192-a485-4630952baea7", Description = "")]
    public class GraphApiPage : StandardPage
    {
        [Ignore]
        public virtual CompositeGraphObject CompositeGraphObject { get; set; }

    }
}