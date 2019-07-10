using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EPiServer.Shell;

namespace EpiServer.AlloyDemo.GraphAPI.Business.UIDescriptors
{
    /// <summary>
    /// Describes how the UI should appear for <see cref="ContainerPage"/> content.
    /// </summary>
    [UIDescriptorRegistration]
    public class FindPageUIDescriptor : UIDescriptor<FindPage>
    {
        public FindPageUIDescriptor()
            : base("epi-icon__search")
        {
            
        }
    }
}
