using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ContentQuery;
using PowerSlice;

namespace EpiServer.AlloyDemo.GraphAPI.Business.PowerSlice
{
    [ServiceConfiguration(typeof(IContentQuery)), ServiceConfiguration(typeof(IContentSlice))]
    public class BlocksSlice : ContentSliceBase<SiteBlockData>
    {
        public override string Name
        {
            get { return "Blocks"; }
        }
        public override string DisplayName
        {
            get { return "Blocks"; }
        }
    }
}