using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EpiServer.AlloyDemo.GraphAPI.Models.Pages.Blog;
using EPiServer.Shell;

namespace EpiServer.AlloyDemo.GraphAPI.Business.UIDescriptors
{
    /// <summary>
    /// Describes how the UI should appear for <see cref="ContainerPage"/> content.
    /// </summary>
    [UIDescriptorRegistration]
    public class BlogPageUIDescriptor : UIDescriptor<BlogItemPage>
    {
        public BlogPageUIDescriptor()
            : base("epi-icon__blog")
        {
            
        }
    }
}
