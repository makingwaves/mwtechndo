using EpiServer.AlloyDemo.GraphAPI.Models.Pages.Blog;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using PowerSlice;

namespace EpiServer.AlloyDemo.GraphAPI.Business.PowerSlice
{
    [ServiceConfiguration(typeof(IContentQuery)), ServiceConfiguration(typeof(IContentSlice))]
    public class BlogSlice : ContentSliceBase<BlogItemPage>
    {
        public override string Name
        {
            get { return "Blogs"; }
        }

        public override string DisplayName
        {
            get { return "Blogs"; }
        }
    }
}