using System.Collections.Generic;
using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;

namespace EpiServer.AlloyDemo.GraphAPI.Models.ViewModels
{
    public class CarouselViewModel
    {
        public List<CarouselItemBlock> Items { get; set; }

        public CarouselBlock CurrentBlock { get; set; }
    }

}
