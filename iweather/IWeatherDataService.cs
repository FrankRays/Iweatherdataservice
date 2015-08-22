using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iweather
{
    //interface on the functions the developer needs to implement
    interface IWeatherDataService
    {
         WeatherData GetWeatherData(Location location);
    }


}
