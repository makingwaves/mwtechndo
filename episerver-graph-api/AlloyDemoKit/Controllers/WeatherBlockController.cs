using System.Web.Mvc;
using EpiServer.AlloyDemo.GraphAPI.Models.Blocks;
using EpiServer.AlloyDemo.GraphAPI.Models.ViewModels;
using EPiServer.Web.Mvc;
using WeatherService;

namespace EpiServer.AlloyDemo.GraphAPI.Controllers
{
    public class WeatherBlockController : BlockController<WeatherBlock>
    {
        [OutputCache(Duration = 120)]
        public override ActionResult Index(WeatherBlock currentBlock)
        {
            string unit = currentBlock.DisplayCelsius ? "C" : "F";
            OpenWeatherMapApiClient client = new OpenWeatherMapApiClient("b6d85c82ae14e8d2819f6f5542565201", units: currentBlock.DisplayCelsius ? Units.Metric : Units.Imperial);
            var results = client.GetWeaterByCityNameAsync(currentBlock.City, currentBlock.Country).Result;

            WeatherBlockViewModel model = new WeatherBlockViewModel()
            {
                Heading = currentBlock.Heading,
                Location = currentBlock.City + ", " + currentBlock.Country,
                Windspeed = results.Wind.Speed,
                Humidity = results.Main.Humidity,
                Pressure = results.Main.Pressure,
                Time = results.Timestamp,
                Temperature = results.Main.Temperature,
                Unit = unit
            };

            return PartialView("WeatherDisplay", model);
        }
    }
}
