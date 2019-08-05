using EPiServer.Data.Dynamic;

namespace EpiServer.AlloyDemo.GraphAPI.Business.Blog
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore=true)]
    public class TagItem : IDynamicData
    {

        public string TagName { get; set; }
        public int Count { get; set; }
        public int Weight { get; set; }
        public string Url { get; set; }

        public EPiServer.Data.Identity Id
        {
            get;
            set;
        }
    }
}