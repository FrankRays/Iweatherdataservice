using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iweather
{
    static class Program
    {
 
        // The main entry point for the application.

        [STAThread]
        static void Main()
        {

            //sample code of how to implement the factory and the interface

            Location loc = new Location();

            loc.cityName = "London";
            loc.countryName = "UK";

            var WUNDERGROUND = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WUNDERGROUND, loc);
            var OPEN_MAP     = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.OPENMAP, loc);
            var WORLDWEATHERONLINE = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WORLDWEATHERONLINE, loc);
        }
    }
}
