using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using PowerSlice;

namespace EpiServer.AlloyDemo.GraphAPI.Business.PowerSlice
{
    [ServiceConfiguration(typeof(IContentQuery)), ServiceConfiguration(typeof(IContentSlice))]
    public class PagesSlice : ContentSliceBase<SitePageData>
    {
        public override string Name
        {
            get { return "Pages"; }
        }
        public override string DisplayName
        {
            get { return "Pages"; }
        }
    }
}