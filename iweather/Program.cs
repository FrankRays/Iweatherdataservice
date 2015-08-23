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


            //declaring and assiging Location object
            Location loc = new Location();
            loc.cityName = "London";
            loc.countryName = "UK";


            //requesting the 1st provider using the provider identifier in the factory
            IWeatherDataService service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WUNDERGROUND);

            //recieving a WeatherData object from the first provider
            WeatherData weatherData = service.GetWeatherData(loc);

            //printing the WeatherData fields, OUTPUT Example : WUNDERGROUND : London, 24 celsius
            System.Console.WriteLine("WUNDERGROUND : " + weatherData.cityName + ", " + weatherData.temp + " celsius");


            //requesting the 2nd provider using the provider identifier in the factory
            service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.OPENMAP);

            //recieving a WeatherData object from the 2nd provider
            weatherData = service.GetWeatherData(loc);

            //printing the WeatherData fields, OUTPUT Example : OPENMAP : London, 24 celsius
            System.Console.WriteLine("OPENMAP : " + weatherData.cityName + ", " + weatherData.temp + " celsius");


            //requesting the 3rd provider using the provider identifier in the factory
            service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WORLDWEATHERONLINE);

            //recieving a WeatherData object from the 3rd provider
            weatherData = service.GetWeatherData(loc);

            //printing the WeatherData fields, OUTPUT Example : WORLDWEATHERONLINE : London, 24 celsius
            System.Console.WriteLine("WORLDWEATHERONLINE : " + weatherData.cityName + ", " + weatherData.temp + " celsius");

        }
    }
}
