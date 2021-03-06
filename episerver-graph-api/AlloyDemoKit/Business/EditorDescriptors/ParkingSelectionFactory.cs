using System.Collections.Generic;
using System.Linq;
using EpiServer.AlloyDemo.GraphAPI.Business.Parking;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;

namespace EpiServer.AlloyDemo.GraphAPI.Business.EditorDescriptors
{
    /// <summary>
    /// Provides a list of options corresponding to available parking garages
    /// </summary>
    /// <seealso cref="ParkingGarageSelector"/>
    public class ParkingSelectionFactory : ISelectionFactory
    {
        private Injected<ParkingGateway> ParkingGateway { get; set; }

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var locations = ParkingGateway.Service.GetLocations();

            return new List<SelectItem>(locations.Select(c => new SelectItem { Value = c, Text = c }));
        }
    }
}
