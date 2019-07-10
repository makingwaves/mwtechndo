using EPiServer.Core;

namespace EpiServer.AlloyDemo.GraphAPI.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
