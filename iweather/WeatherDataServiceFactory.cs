using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iweather
{
    //calles the right site by the enum values and returns the specific site service functions
    public class WeatherDataServiceFactory 
    {
        public enum Providers { OPENMAP, WUNDERGROUND , WORLDWEATHERONLINE };

        public static WeatherData getWeatherDataService(Providers site,Location loc)
        {

            IWeatherDataService provider = null;
            WeatherData tmp = null;

            switch(site)
            {
                case Providers.OPENMAP:  
                              
                    provider = WeatherDataProviderOpenWeatherMap.Instance;
                    
                    try
                    {
                        tmp = provider.GetWeatherData(loc);
                    }
                    catch (WeatherDataServiceException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case Providers.WUNDERGROUND:

                    provider = WeatherDataProviderWunderGround.Instance;
                    try
                    {
                        tmp = provider.GetWeatherData(loc);
                    }
                    catch (WeatherDataServiceException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case Providers.WORLDWEATHERONLINE:

                    provider = WeatherDataProviderWorldWeatherOnline.Instance;
                    try
                    {
                        tmp = provider.GetWeatherData(loc);
                    }
                    catch (WeatherDataServiceException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

            }

            return tmp;
        }

        
    }
}
