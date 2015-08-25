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

            //printing the WeatherData fields, OUTPUT Example :
            //WUNDERGROUND: city: London, temp: 14 celsius, humidity: 94 %, pressure: 1004 hPa, wind: 20 kPh West
            System.Console.WriteLine("WUNDERGROUND : city : " + weatherData.cityName +
                                      ", temp : " + weatherData.temp + " celsius" +
                                      ", humidity : " + weatherData.humidity +
                                      ", pressure : " + weatherData.pressure + " hPa" +
                                      ", wind : " + weatherData.windSpeed + " kPh" +
                                      " " + weatherData.windDirection);


            //requesting the 2nd provider using the provider identifier in the factory
            service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.OPENMAP);

            //recieving a WeatherData object from the 2nd provider
            weatherData = service.GetWeatherData(loc);

            //printing the WeatherData fields, OUTPUT Example :
            //OPENMAP : city : London, temp : 14.1 celsius, humidity : 82%, pressure : 1002 hPa, wind : 24.12 kPh W
            System.Console.WriteLine("OPENMAP : city : " + weatherData.cityName +
                                      ", temp : " + weatherData.temp + " celsius" +
                                      ", humidity : " + weatherData.humidity +
                                      ", pressure : " + weatherData.pressure + " hPa" +
                                      ", wind : " + weatherData.windSpeed + " kPh" +
                                      " " + weatherData.windDirection);


            //requesting the 3rd provider using the provider identifier in the factory
            service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.Providers.WORLDWEATHERONLINE);

            //recieving a WeatherData object from the 3rd provider
            weatherData = service.GetWeatherData(loc);

            //printing the WeatherData fields,OUTPUT Example :
            //WORLDWEATHERONLINE : city : London, United Kingdom, temp : 16 celsius, humidity : 82%, pressure : 1003 hPa, wind : 24 kPh W
            System.Console.WriteLine("WORLDWEATHERONLINE : city : " + weatherData.cityName +
                                      ", temp : " + weatherData.temp + " celsius" +
                                      ", humidity : " + weatherData.humidity +
                                      ", pressure : " + weatherData.pressure + " hPa" +
                                      ", wind : " + weatherData.windSpeed + " kPh" +
                                      " " + weatherData.windDirection);

        }
    }
}
