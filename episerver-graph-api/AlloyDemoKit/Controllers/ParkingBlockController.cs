using System;
using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Business.Parking;
using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;
using EpiServer.AlloyDemo.GraphAPI.Models.ViewModels;
using EPiServer.Web.Mvc;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class ParkingBlockController : BlockController<ParkingBlock>
    {
        
        public override ActionResult Index(ParkingBlock currentBlock)
        {
            ParkingGateway gateway = new ParkingGateway();

            ParkingGarage garage = gateway.GetParkingGarage(currentBlock.Location);
            ParkingViewModel model = new ParkingViewModel()
            {
                Heading = currentBlock.Heading,
                Location = currentBlock.Location,
                Address = garage.Address,
                TotalCapacity = garage.ParkingStatus.TotalCapacity,
                AvailableCapacity = garage.ParkingStatus.AvailableCapacity,
                IsOpen = garage.ParkingStatus.Open,
                LastUpdated = Convert.ToDateTime(garage.LastModifiedDate)
            };

            return PartialView(model);
        }
    }
}
