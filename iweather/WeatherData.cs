using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Iweather
{

    //this is the data sturcture that we build will calling services

    public class WeatherData
    {       
        public string cityName { get; set; }
        public double temp { get; set; }
        public int pressure { get; set; }
        public string humidity { get; set; }
        public double windSpeed { get; set; }
        public string windDirection { get; set; }
    }
}
