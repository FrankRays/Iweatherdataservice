using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iweather
{
    //calles the right site by the enum values and returns the specific site service 
    public class WeatherDataServiceFactory 
    {
        public enum Providers { OPENMAP, WUNDERGROUND , WORLDWEATHERONLINE };

        public static IWeatherDataService getWeatherDataService(Providers site)
        {

            switch(site)
            {

                case Providers.OPENMAP:

                    return WeatherDataProviderOpenWeatherMap.Instance;

                case Providers.WUNDERGROUND:

                    return WeatherDataProviderWunderGround.Instance;

                case Providers.WORLDWEATHERONLINE:

                    return WeatherDataProviderWorldWeatherOnline.Instance;

                default:

                    return null;

            }

        }
       
    }
}
