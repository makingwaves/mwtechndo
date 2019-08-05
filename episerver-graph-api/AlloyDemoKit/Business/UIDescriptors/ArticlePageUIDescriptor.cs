using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EPiServer.Shell;

namespace EpiServer.AlloyDemo.GraphAPI.Business.UIDescriptors
{
    /// <summary>
    /// Describes how the UI should appear for <see cref="ContainerPage"/> content.
    /// </summary>
    [UIDescriptorRegistration]
    public class ArticlePageUIDescriptor : UIDescriptor<ArticlePage>
    {
        public ArticlePageUIDescriptor()
            : base("epi-icon__article")
        {
            
        }
    }
}
