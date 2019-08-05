using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;
using EpiServer.AlloyDemo.GraphAPI.Models.Media;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class ImageGalleryBlockController : BlockController<ImageGalleryBlock>
    {
        public override ActionResult Index(ImageGalleryBlock currentBlock)
        {
            var repo = ServiceLocator.Current.GetInstance<IContentRepository>();
            var images = repo.GetChildren<ImageFile>(currentBlock.Images);

            return PartialView(images);
        }
    }
}
