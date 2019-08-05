using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;
using EPiServer.Shell;

namespace EpiServer.AlloyDemo.GraphAPI.Business.UIDescriptors
{
    /// <summary>
    /// Describes how the UI should appear for <see cref="WeatherBlock"/> content.
    /// </summary>
    [UIDescriptorRegistration]
    public class WeatherBlockUIDescriptor : UIDescriptor<WeatherBlock>
    {
        public WeatherBlockUIDescriptor()
            : base(ContentTypeCssClassNames.SharedBlock)
        {
            DefaultView = CmsViewNames.AllPropertiesView;
        }
    }
}
