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

            //example of use , sample code of how to implement the factory and the interface

            Location loc = new Location();

            loc.cityName = "London";
            loc.countryName = "UK";

            IWeatherDataService service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WUNDERGROUND);

            WeatherData weatherData = service.GetWeatherData(loc);

            System.Console.WriteLine("WUNDERGROUND : " + weatherData.cityName + " " + weatherData.temp);

            service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.OPENMAP);

            weatherData = service.GetWeatherData(loc);

            System.Console.WriteLine("OPENMAP : " + weatherData.cityName + " " + weatherData.temp);


            service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WORLDWEATHERONLINE);

            weatherData = service.GetWeatherData(loc);

            System.Console.WriteLine("WORLDWEATHERONLINE : " + weatherData.cityName + " " + weatherData.temp);

        }
    }
}
