using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using PowerSlice;

namespace EpiServer.AlloyDemo.GraphAPI.Business.PowerSlice
{
    [ServiceConfiguration(typeof(IContentQuery)), ServiceConfiguration(typeof(IContentSlice))]
    public class NewsSlice : ContentSliceBase<NewsPage>
    {
        public override string Name
        {
            get { return "News"; }
        }

        public override string DisplayName
        {
            get { return "News"; }
        }

        public override int Order
        {
            get { return 5; }
        }

        public override bool HideSortOptions
        {
            get
            {
                return false;
            }
        }


    }
}