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
            loc.countryName =  "UK";

            WeatherData WUNDERGROUND = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WUNDERGROUND, loc);
            WeatherData OPENMAP     = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.OPENMAP, loc);
            WeatherData WORLDWEATHERONLINE = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WORLDWEATHERONLINE, loc);

            loc.cityName = "jerusalem";
            loc.countryName = "Israel";

            WUNDERGROUND = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WUNDERGROUND, loc);
            OPENMAP = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.OPENMAP, loc);
            WORLDWEATHERONLINE = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WORLDWEATHERONLINE, loc);

        }
    }
}
