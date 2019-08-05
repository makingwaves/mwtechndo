using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using PowerSlice;

namespace EpiServer.AlloyDemo.GraphAPI.Business.PowerSlice
{

    [ServiceConfiguration(typeof(IContentQuery)), ServiceConfiguration(typeof(IContentSlice))]
    public class ArticleSlice : ContentSliceBase<ArticlePage>
    {
        public override string Name
        {
            get { return "Articles"; }
        }

        public override string DisplayName
        {
            get { return "Articles"; }
        }

        public override int Order
        {
            get { return 4; }
        }

        public override bool HideSortOptions
        {
            get
            {
                return true;
            }
        }
    }
}