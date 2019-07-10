using EpiServer.AlloyDemo.GraphAPI.Models.Pages;
using EPiServer.Find.UnifiedSearch;

namespace EpiServer.AlloyDemo.GraphAPI.Models.ViewModels
{
    public class FindPageViewModel : PageViewModel<FindPage>
    {

        public FindPageViewModel(FindPage currentPage): base(currentPage)
        {
        }

        public UnifiedSearchResults Results { get; set; }
        public string SearchedQuery { get; set; }
        public int NumberOfHits { get; set; }
    }
}