using System.Linq;
using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Business;
using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;
using EpiServer.AlloyDemo.GraphAPI.Models.ViewModels;
using EPiServer;
using EPiServer.Web.Mvc;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class CarouselBlockController : BlockController<CarouselBlock>
    {
        private readonly ContentLocator contentLocator;
        private IContentLoader contentLoader;
        public CarouselBlockController(ContentLocator contentLocator, IContentLoader contentLoader)
        {
            this.contentLocator = contentLocator;
            this.contentLoader = contentLoader;
        }

        public override ActionResult Index(CarouselBlock currentBlock)
        {
            if (currentBlock.MainContentArea == null) {
                return PartialView("Carousel", null);
            }
            var model = new CarouselViewModel
            {
                Items =
                    currentBlock.MainContentArea.FilteredItems.Select(
                        cai => contentLoader.Get<CarouselItemBlock>(cai.ContentLink)).ToList(),
                        CurrentBlock = currentBlock
            };
            

            return PartialView("Carousel", model);
        }

    }
}
